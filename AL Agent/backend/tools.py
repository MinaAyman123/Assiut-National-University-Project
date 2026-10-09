from rag import MedicalRAG
import os

# تحديد مسار ملف البيانات
current_dir = os.path.dirname(os.path.abspath(__file__))
data_path = os.path.join(current_dir, "medical_data.json")

rag = MedicalRAG(data_path=data_path)

def symptoms_tool(symptoms: str):
    """Returns possible diseases based on symptoms"""
    results = rag.retrieve(symptoms)
    return results


def analysis_tool(report_text: str):
    """
    تحليل التقارير الطبية - بيدور في JSON على:
    - تحاليل متطابقة (CBC, Thyroid, Liver, Kidney)
    - قيم غير طبيعية
    - أمراض مرتبطة بالتحاليل
    """
    report_lower = report_text.lower()
    
    # نجيب كل الأمراض من RAG
    all_diseases = rag.retrieve(report_text, top_k=50)
    
    # فلترة الأمراض اللي ليها تحاليل (analysis)
    findings = []
    for disease in all_diseases:
        if "analysis" in disease:
            analysis_data = disease["analysis"]
            
            # نشوف إذا التقرير فيه أي كلمات من التحاليل
            matched = []
            
            # كشف نوع التحليل
            test_type = analysis_data.get("test_type", "")
            if test_type.lower() in report_lower:
                matched.append(f"Test type: {test_type}")
            
            # كشف القيم غير الطبيعية
            for finding in analysis_data.get("abnormal_findings", []):
                if finding.lower() in report_lower:
                    matched.append(finding)
            
            # كشف الكلمات المفتاحية
            for keyword in analysis_data.get("keywords", []):
                if keyword.lower() in report_lower:
                    matched.append(keyword)
            
            if matched:
                findings.append({
                    "disease": disease["disease"],
                    "doctor": disease["doctor"],
                    "emergency": disease.get("emergency", False),
                    "matched_findings": matched,
                    "analysis_details": analysis_data,
                    "confidence": "high" if len(matched) > 1 else "medium"
                })
    
    if findings:
        return {
            "findings": findings,
            "message": f"📊 Report analysis complete. Found {len(findings)} condition(s).",
            "emergency": any(f["emergency"] for f in findings)
        }
    
    return {
        "message": "No clear abnormalities detected in the report.",
        "emergency": False,
        "findings": []
    }


def emergency_tool(symptoms: str):
    """
    كشف الطوارئ المتقدم - بيدور في JSON على:
    - كل الأمراض اللي marked as emergency
    - كلمات طوارئ محددة لكل مرض
    - مستوى الطوارئ
    """
    symptoms_lower = symptoms.lower()
    
    # نجيب كل الأمراض من RAG
    all_diseases = rag.retrieve(symptoms, top_k=50)
    
    # فلترة الأمراض الطارئة
    emergencies = []
    for disease in all_diseases:
        if disease.get("emergency", False):
            disease_symptoms = [s.lower() for s in disease.get("symptoms", [])]
            
            # نشوف إذا فيه تطابق بين الأعراض
            matched_symptoms = [s for s in disease_symptoms if s in symptoms_lower]
            
            if matched_symptoms:
                emergencies.append({
                    "disease": disease["disease"],
                    "doctor": disease["doctor"],
                    "matched_symptoms": matched_symptoms,
                    "emergency": True
                })
    
    if emergencies:
        return {
            "emergency": True,
            "possible_emergencies": emergencies,
            "message": f"🚨 EMERGENCY DETECTED: {', '.join([e['disease'] for e in emergencies])}",
            "suggested_action": "Seek immediate medical care or call emergency services",
            "doctors": list(set([e["doctor"] for e in emergencies]))
        }
    
    return {
        "emergency": False,
        "message": "No emergency symptoms detected. Continue monitoring your condition."
    }
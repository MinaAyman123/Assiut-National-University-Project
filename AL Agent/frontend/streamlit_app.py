import streamlit as st
import requests

# إعدادات الصفحة
st.set_page_config(
    page_title="AI Medical Assistant",
    page_icon="🩺",
    layout="wide"
)

# ========== مهم: تهيئة session state ==========
if "symptoms" not in st.session_state:
    st.session_state.symptoms = ""

st.title("🩺 AI Medical Assistant")
st.markdown("---")

col1, col2 = st.columns([2, 1])

with col1:
    st.subheader("📝 Symptoms Checker")
    
    # ========== ربط الـ text area بـ session state ==========
    symptoms = st.text_area(
        "Describe your symptoms in detail:",
        value=st.session_state.symptoms,  # هنا الرابط
        placeholder="Example: I have fever, headache, and cough for 3 days...",
        height=150
    )
    
    # تحديث session state عند الكتابة
    st.session_state.symptoms = symptoms
    # ========== نهاية الربط ==========
    
    uploaded_file = st.file_uploader(
        "Upload medical report (PDF) - Optional",
        type=["pdf"]
    )
    
    analyze_button = st.button("🔍 Analyze My Symptoms", type="primary", use_container_width=True)

with col2:
    st.subheader("ℹ️ About")
    st.info(
        """
        **How it works:**
        1. Enter your symptoms
        2. AI analyzes using medical database
        3. Get possible conditions
        4. Doctor recommendation
        5. Emergency detection
        
        ⚠️ This is NOT a substitute for professional medical advice.
        """
    )

# منطقة عرض النتائج
st.markdown("---")
st.subheader("📋 Diagnosis Result")
result_placeholder = st.empty()

# معالجة الطلب
if analyze_button:
    if not symptoms:
        st.error("❌ Please enter your symptoms first!")
    else:
        with st.spinner("🩺 Analyzing your symptoms with AI..."):
            try:
                files = {}
                data = {"symptoms": symptoms}
                
                if uploaded_file:
                    files["report"] = uploaded_file.getvalue()
                
                response = requests.post(
                    "http://localhost:8000/chat",
                    files=files,
                    data=data,
                    timeout=60
                )
                
                if response.status_code == 200:
                    result = response.json()
                    response_text = result.get("response", "No response from AI")
                    
                    with result_placeholder.container():
                        if "EMERGENCY" in response_text.upper() or "⚠️" in response_text:
                            st.error("🚨 **EMERGENCY DETECTED** 🚨")
                            st.warning(response_text)
                        else:
                            st.success("✅ Analysis Complete")
                            st.markdown(response_text)
                else:
                    st.error(f"❌ Error: {response.status_code}")
                    
            except requests.exceptions.ConnectionError:
                st.error("❌ Cannot connect to backend server. Make sure FastAPI is running on http://localhost:8000")
            except Exception as e:
                st.error(f"❌ Unexpected error: {str(e)}")

# Sidebar
with st.sidebar:
    st.image("https://img.icons8.com/color/96/000000/medical-doctor.png", width=80)
    st.markdown("## 🏥 Medical Assistant")
    st.markdown("---")
    
    st.markdown("### 🔬 Supported Features:")
    st.markdown("""
    - ✅ Symptom analysis
    - ✅ Disease prediction
    - ✅ Doctor specialty recommendation
    - ✅ Emergency detection
    - ✅ Medical report analysis (PDF)
    """)
    
    st.markdown("---")
    st.markdown("### 📞 When to See a Doctor:")
    st.markdown("""
    - Symptoms lasting > 7 days
    - Severe pain
    - High fever (>39°C)
    - Difficulty breathing
    - Chest pain
    """)
    
    st.markdown("---")
    st.markdown("### 🧪 Test Examples:")
    
    # ========== الأزرار شغالة 100% ==========
    if st.button("🦠 Flu", use_container_width=True):
        st.session_state.symptoms = "I have fever, cough, and headache"
        st.rerun()
    
    if st.button("❤️ Heart Attack", use_container_width=True):
        st.session_state.symptoms = "I have chest pain and shortness of breath"
        st.rerun()
    
    if st.button("🩸 Anemia", use_container_width=True):
        st.session_state.symptoms = "I feel very tired, dizzy, and my skin looks pale"
        st.rerun()
    
    if st.button("🧠 Meningitis", use_container_width=True):
        st.session_state.symptoms = "I have severe headache and stiff neck"
        st.rerun()

st.markdown("---")
st.caption("⚠️ **Medical Disclaimer:** This AI assistant is for informational purposes only. Always consult a qualified healthcare provider for medical advice, diagnosis, or treatment.")
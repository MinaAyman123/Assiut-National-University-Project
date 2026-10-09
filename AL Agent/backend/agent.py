import requests
import json
from tools import symptoms_tool, analysis_tool, emergency_tool

class MedicalAgent:
    def __init__(self, model="qwen2.5-coder:3b", ollama_url="http://localhost:11434"):
        self.model = model
        self.ollama_url = ollama_url

    def decide_tool(self, user_input):
        """اختيار الأداة المناسبة"""
        if "report" in user_input.lower() or "analysis" in user_input.lower():
            return "analysis"
        elif any(w in user_input.lower() for w in ["chest pain", "difficulty breathing", "emergency", "severe headache", "stiff neck"]):
            return "emergency"
        else:
            return "symptoms"

    def run(self, user_input, report_text=None):
        tool_name = self.decide_tool(user_input)

        if tool_name == "symptoms":
            results = symptoms_tool(user_input)
        elif tool_name == "analysis" and report_text:
            results = analysis_tool(report_text)
        elif tool_name == "emergency":
            results = emergency_tool(user_input)
        else:
            results = {"error": "Could not determine tool"}

        final_response = self.generate_response(user_input, results, tool_name)
        return final_response

    def generate_response(self, user_input, tool_output, tool_name):
        """استدعاء Qwen2.5 عبر Ollama API"""
        
        prompt = f"""You are a helpful medical AI assistant. Analyze the following:

USER SYMPTOMS: {user_input}

TOOL USED: {tool_name}

RETRIEVED INFORMATION: {json.dumps(tool_output, ensure_ascii=False)}

Please provide:
1. Possible conditions (based on retrieved info)
2. Recommended doctor specialty
3. If emergency=true, clearly say "⚠️ EMERGENCY: Seek immediate medical care"
4. Advice for the user

Be concise and helpful. This is not a substitute for professional medical advice."""

        response = requests.post(
            f"{self.ollama_url}/api/generate",
            json={
                "model": self.model,
                "prompt": prompt,
                "stream": False,
                "temperature": 0.3
            }
        )
        
        if response.status_code == 200:
            return response.json()["response"]
        else:
            return f"Error with LLM: {response.status_code}. Here's the raw data: {tool_output}"
from fastapi import FastAPI, UploadFile, File, Form
from agent import MedicalAgent
import pypdf
from io import BytesIO

app = FastAPI()
agent = MedicalAgent()

def extract_text_from_pdf(file):
    reader = pypdf.PdfReader(BytesIO(file))
    text = ""
    for page in reader.pages:
        text += page.extract_text()
    return text

@app.post("/chat")
async def chat(symptoms: str = Form(...), report: UploadFile = File(None)):
    report_text = None
    if report:
        content = await report.read()
        report_text = extract_text_from_pdf(content)

    response = agent.run(symptoms, report_text)
    return {"response": response}
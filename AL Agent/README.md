# 🩺 AI Medical Assistant

An intelligent medical assistant that analyzes symptoms, detects emergencies, predicts possible diseases, and recommends the appropriate doctor specialty — powered by **RAG**, **AI Agent**, and **LLM Tool Calling**.

---

## 📌 Overview

**AI Medical Assistant** is a full-stack AI application that helps users understand their symptoms and get preliminary medical guidance. It combines a **retrieval-augmented generation (RAG)** pipeline with an **AI agent** that intelligently selects the right tool based on user input, and a **local LLM** (Qwen2.5-coder via Ollama) to generate natural, human-friendly responses.

> ⚠️ **Disclaimer:** This system is for informational purposes only. It is **NOT** a substitute for professional medical advice, diagnosis, or treatment. Always consult a qualified healthcare provider.

---

## ✨ Features

- 🔍 **Symptom Analysis** — Enter symptoms in natural language and get possible conditions.
- 📊 **Medical Report Analysis** — Upload PDF lab reports; the system extracts abnormal values and matches them to diseases.
- 🚨 **Emergency Detection** — Detects critical symptoms (e.g., chest pain, difficulty breathing) and warns the user.
- 👨‍⚕️ **Doctor Specialty Recommendation** — Suggests the right specialist for each condition.
- 💬 **AI Chatbot** — Natural, conversational responses powered by Qwen2.5-coder.
- 📚 **RAG-Based Retrieval** — Semantic search across 52 diseases using vector embeddings.
- 🧠 **AI Agent with Tool Calling** — Automatically decides which tool to invoke based on user input.

---

## 🏗️ Architecture

```
┌─────────────┐
│    User     │  (symptoms / PDF upload)
└──────┬──────┘
       │
       ▼
┌─────────────┐
│  Streamlit  │  Frontend (Port 8501)
└──────┬──────┘
       │ HTTP
       ▼
┌─────────────┐
│   FastAPI   │  Backend (Port 8000)
└──────┬──────┘
       │
       ▼
┌─────────────┐
│ MedicalAgent│  Decides which tool to use
└──────┬──────┘
       │
   ┌───┴───────────────┬────────────────┐
   ▼                   ▼                ▼
┌──────────────┐ ┌──────────────┐ ┌──────────────┐
│symptoms_tool │ │analysis_tool │ │emergency_tool│
└──────┬───────┘ └──────┬───────┘ └──────┬───────┘
       │                │                │
       └────────────────┼────────────────┘
                        ▼
                 ┌─────────────┐
                 │ ChromaDB    │  Vector Database (RAG)
                 └──────┬──────┘
                        │
                        ▼
                 ┌─────────────┐
                 │   Ollama    │  Qwen2.5-coder:3b (Port 11434)
                 └─────────────┘
```

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| **Frontend** | Streamlit |
| **Backend** | FastAPI |
| **AI Agent** | Custom Python Agent (Tool Calling) |
| **RAG** | ChromaDB + Sentence Transformers |
| **Embeddings** | `all-MiniLM-L6-v2` |
| **LLM** | Ollama (`qwen2.5-coder:3b`) |
| **PDF Parsing** | PyPDF |
| **Language** | Python 3.10+ |

---

## 📂 Project Structure

```
AI_Medical_Assistant/
│
├── backend/
│   ├── app.py                 # FastAPI entry point
│   ├── agent.py               # AI Agent (tool selection + LLM call)
│   ├── tools.py               # symptoms, analysis, emergency tools
│   ├── rag.py                 # RAG (ChromaDB + embeddings)
│   └── medical_data.json      # Medical knowledge base (52 diseases)
│
├── frontend/
│   └── streamlit_app.py       # Streamlit UI
│
├── requirements.txt
└── README.md
```

---

## 🔧 Tools

The AI Agent selects one of three tools based on the user's input:

### 1. `symptoms_tool`
- **Input:** Natural language symptoms (e.g., *"I have fever and cough"*)
- **Process:** Semantic search in ChromaDB
- **Output:** List of possible diseases with matching doctors

### 2. `analysis_tool`
- **Input:** Extracted text from an uploaded PDF report
- **Process:** Matches abnormal findings & keywords against the medical database
- **Output:** Possible conditions with matched test results

### 3. `emergency_tool`
- **Input:** User symptoms
- **Process:** Checks for critical keywords (chest pain, difficulty breathing, etc.)
- **Output:** Emergency warning + suggested action

---

## 📊 Dataset

The medical knowledge base (`medical_data.json`) contains:

| Metric | Count |
|--------|-------|
| **Total Diseases** | 52 |
| **Medical Specialties** | 20 |
| **Emergency Conditions** | 15 |
| **Diseases with Lab Analysis** | 25 |
| **Tools Available** | 3 |

Each disease entry includes:
- `disease` — disease name
- `symptoms` — list of associated symptoms
- `doctor` — recommended specialty
- `emergency` — whether it's a critical condition
- `analysis` *(optional)* — lab test types, abnormal findings, and keywords

---

## 🚀 Installation & Setup

### Prerequisites
- Python 3.10 or higher
- [Ollama](https://ollama.com/) installed

### 1. Clone the repository
```bash
git clone [https://github.com/your-username/ai-medical-assistant.git](https://github.com/your-username/ai-medical-assistant.git)
cd ai-medical-assistant
```

### 2. Create a virtual environment
```bash
python -m venv venv

# Windows
venv\Scripts\activate

# macOS / Linux
source venv/bin/activate
```

### 3. Install dependencies
```bash
pip install -r requirements.txt
```

### 4. Pull the LLM model
```bash
ollama pull qwen2.5-coder:3b
```

### 5. Start Ollama
```bash
ollama serve
```

---

## ▶️ Running the Project

You need **three terminals** running simultaneously.

### Terminal 1 — Ollama
```bash
ollama serve
```

### Terminal 2 — FastAPI Backend
```bash
cd backend
uvicorn app:app --reload --port 8000
```

You should see:
```
✅ Loaded 52 medical records into RAG
INFO:     Uvicorn running on [http://127.0.0.1:8000](http://127.0.0.1:8000)
```

### Terminal 3 — Streamlit Frontend
```bash
cd frontend
streamlit run streamlit_app.py
```

Then open your browser at:
```
http://localhost:8501
```

---

## 🧪 Usage Examples

### Example 1 — Common Symptoms
**Input:**
```
I have fever, cough, and headache
```
**Output:**
```
Possible conditions: Influenza, Common Cold, COVID-19
Recommended doctor: Internal Medicine
Advice: Rest, stay hydrated, and monitor your symptoms.
```

### Example 2 — Emergency
**Input:**
```
I have chest pain and shortness of breath
```
**Output:**
```
🚨 EMERGENCY DETECTED
Possible condition: Heart Attack
Recommended doctor: Cardiology
Action: Call emergency services immediately.
```

### Example 3 — PDF Report
**Upload:** A CBC lab report with low hemoglobin
**Output:**
```
📊 Report Analysis Complete
Findings: Low hemoglobin, low MCV
Possible condition: Iron Deficiency Anemia
Recommended doctor: Hematology
```

---

## 🔌 API Reference

### `POST /chat`
Send symptoms (and optionally a PDF report) for analysis.

**Form Data:**
| Field | Type | Required |
|-------|------|----------|
| `symptoms` | string | ✅ Yes |
| `report` | file (PDF) | ❌ Optional |

**Response:**
```json
{
  "response": "Possible conditions: Flu. Recommended doctor: Internal Medicine."
}
```

### `GET /health`
Health check endpoint.

**Response:**
```json
{ "status": "ok" }
```

---

## ⚙️ Configuration

| Variable | Default | Description |
|----------|---------|-------------|
| `OLLAMA_URL` | `http://localhost:11434` | Ollama API endpoint |
| `MODEL` | `qwen2.5-coder:3b` | LLM model name |
| `TOP_K` | `5` | Number of RAG results to retrieve |

---

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

---

## 📜 License

This project is licensed under the **MIT License**. See the `LICENSE` file for details.

---

## ⚠️ Medical Disclaimer

This project is intended for **educational and informational purposes only**.

- It does **NOT** provide medical diagnoses.
- It is **NOT** a substitute for professional medical advice.
- Always consult a qualified healthcare provider for any medical concerns.
- In case of emergency, call your local emergency number immediately.

---

## 🙏 Acknowledgements

- [Ollama](https://ollama.com/) — for local LLM inference
- [ChromaDB](https://www.trychroma.com/) — for vector storage
- [Sentence Transformers](https://www.sbert.net/) — for embeddings
- [FastAPI](https://fastapi.tiangolo.com/) — for the backend
- [Streamlit](https://streamlit.io/) — for the frontend

---

## 📬 Contact

**Your Name**  
📧 your.email@example.com  
🔗 [GitHub](https://github.com/your-username)

---

<p align="center">Made with ❤️ for better healthcare accessibility</p>
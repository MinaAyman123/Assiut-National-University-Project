import json
from sentence_transformers import SentenceTransformer
import chromadb
from chromadb.utils import embedding_functions
import os

class MedicalRAG:
    def __init__(self, data_path="medical_data.json"):
        self.model = SentenceTransformer('all-MiniLM-L6-v2')
        self.client = chromadb.Client()
        self.collection = self.client.create_collection(
            name="medical_kb",
            embedding_function=embedding_functions.SentenceTransformerEmbeddingFunction()
        )
        self.load_data(data_path)

    def load_data(self, data_path):
        if not os.path.exists(data_path):
            print(f"⚠️ Warning: {data_path} not found. Creating empty collection.")
            return
            
        with open(data_path, "r") as f:
            data = json.load(f)

        for idx, record in enumerate(data):
            # بناء نص للبحث
            symptoms_str = ", ".join(record.get("symptoms", []))
            text = f"Disease: {record['disease']}. Symptoms: {symptoms_str}. Doctor: {record['doctor']}"
            
            self.collection.add(
                documents=[text],
                metadatas=[record],
                ids=[str(idx)]
            )
        print(f"✅ Loaded {len(data)} medical records into RAG")

    def retrieve(self, query, top_k=3):
        results = self.collection.query(query_texts=[query], n_results=top_k)
        return results['metadatas'][0] if results['metadatas'] else []
import json
import os
from datetime import datetime

FILE_NAME = "task.json"

def load_tasks():
    if not os.path.exists(FILE_NAME):
        return []
    
    with open(FILE_NAME, "r") as f:
        return json.load(f)
    
def save_tasks(tasks):
    with open(FILE_NAME, "w") as f:
        json.dump(tasks, f, indent=4)
        
def get_new_id(tasks):
    return max([t["id"] for t in tasks], default=0) + 1

def get_time():
    return datetime.now().isoformat()



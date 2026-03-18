from utils.storage import *
def add_task(desc):
    tasks = load_tasks()
    
    task = {
        "id": get_new_id(tasks),
        "description": desc,
        "status": "todo",
        "createdAt": get_time(),
        "updatedAt": get_time()
    }
    
    tasks.append(task)
    save_tasks(tasks)
    
    print(f"Added (ID: {task['id']})")
    
def update_task(id, desc):
    tasks = load_tasks()
    
    for t in tasks:
        if t["id"] == id:
            t["description"] = desc
            t["updatedAt"] = get_time()
            save_tasks(tasks)
            print("Updated")
            return
    print("Not found")
    
def delete_task(id):
    tasks = load_tasks()
    tasks = [t for t in tasks if t["id"] != id]
    save_tasks(tasks)
    print("Deleted")
  
def mark(id, status):
    tasks = load_tasks()
    
    for t in tasks:
        if t["id"] == id:
            t["status"] = status
            t["updatedAt"] = get_time()
            save_tasks(tasks)
            print(f"Marked {status}")
            return
    
    print("Not found")
    
def list_tasks(status=None):
    tasks = load_tasks()
    
    if status:
        tasks = [t for t in tasks if t["status"] == status]
        
    for t in tasks:
        print(f"{t['id']} - {t['description']} [{t['status']}]")
        
print("test")
        
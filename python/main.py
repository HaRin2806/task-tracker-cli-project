import sys
from utils.commands import *

def main():
    args = sys.argv
    
    if len(args) < 2:
        print("No command")
        return
    
    cmd = args[1]
    
    try:
        if cmd == "add":
            add_task(args[2])
        elif cmd == "update":
            update_task(int(args[2]))
        elif cmd == "delete":
            delete_task(int(args[2]))
        elif cmd == "mark-in-progress":
            mark(int(args[2]), "in-progress")    
        elif cmd == "mark-done":
            mark(int(args[2]), "done")
        elif cmd == "list":
            if len(args) > 2:
                list_tasks(args[2])
            else:
                list_tasks()
        else:
            print("Unknown command")
    except Exception as e:
        print("Error:", e)
        
if __name__ == "__main__":
    main()
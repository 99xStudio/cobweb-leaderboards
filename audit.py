import audit_auth
import requests
import os
import dateparser

SB_URL = "https://croiqlfjgofhokfrpagk.supabase.co"

def fetch_all_scores():
    url = SB_URL + "/rest/v1/Leaderboards?select=*"
    headers = {
        "apikey": audit_auth.SERVICE,
        "Authorization": "Bearer " + audit_auth.SERVICE
    }
    response = requests.get(url, headers=headers)
    return response.json()

def remove_entry(id: int):
    url = SB_URL + "/rest/v1/Leaderboards?id=eq." + str(id)
    headers = {
        "apikey": audit_auth.SERVICE,
        "Authorization": "Bearer " + audit_auth.SERVICE
    }
    requests.delete(url, headers=headers)

def get_average_score(scores):
    total = 0
    for score in scores:
        total += score["score"]
    return total / len(scores)

def clear():
    os.system("clear")

if __name__ == "__main__":
    delete_count = 0
    scores = fetch_all_scores()

    clear()
    print("Cobweb Leaderboard auditor V1")
    print("Current average score:", get_average_score(scores))
    print()
    print("Type y or just press enter to keep score,")
    print("Type n to remove the score")
    print()
    if input("Press enter to start, or q to exit: ") == "q":
        exit(0)

    for entry in scores:
        clear()
        print("ID:", entry["id"])
        print("Player:", entry["player_name"])
        print("Score:", entry["score"])
        
        date = dateparser.parse(entry["created_at"])
        print(date.ctime())
        
        action = input("[Y/n]> ")
        if action != "n":
            continue

        delete_count += 1
        remove_entry(entry["id"])
        
    print(delete_count, "score(s) deleted")

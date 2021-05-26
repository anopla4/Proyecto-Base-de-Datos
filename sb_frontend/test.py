from requests import request, Response

api_dns = "http://localhost:5000"
id = 5
url = f"{api_dns}/api/player/{id}"

response  = request("GET", url)

print(response.json())
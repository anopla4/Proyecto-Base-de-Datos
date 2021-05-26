from flask import Flask
import json


app = Flask(__name__)

api_url = "/api"

@app.route('/')
def hello_world():
    return 'Hello, World!'

@app.route(api_url + "/player/<id>")
def player(id):
    return json.dumps({
        "name": "Alexander Malleta",
        "age": 45,
    })

if __name__ == "__main__":
    app.run()

    
    
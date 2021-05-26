import React, { Component } from "react";
import { Container } from "react-bootstrap";
import "../../containers/App/App.css";
import Players from "../../components/Players/Players";

class PlayersGeneral extends Component {
  state = {
    players: [
      {
        id: 1,
        name: "Alexander Malleta",
        positions: ["Primera base"],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_team: "Retirado",
        years_of_experience: 20,
        ave: 301,
      },
      {
        id: 2,
        name: "Pedro Luis Lazo",
        positions: ["Lanzador"],
        img: "http://localhost:8000/src/logos/pedro_luis_lazo.jpg",
        age: 49,
        teams: ["Pinar del Río"],
        current_team: "Retirado",
        years_of_experience: 20,
        era: 3.22,
        hand: "Derecha",
      },
    ],
  };

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">Jugadores de pelota</h1>
        <Players players={this.state.players} />
      </Container>
    );
  }
}

export default PlayersGeneral;

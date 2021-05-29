import React, { Component } from "react";
import { Container } from "react-bootstrap";
import "../../containers/App/App.css";
import Players from "../../components/Players/Players";
import Add from "../../components/Add/Add";

class PlayersGeneral extends Component {
  state = {
    players: [
      {
        id: 1,
        name: "Alexander Malleta",
        position: [{ id: 1, positionName: "Primera base" }],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_Team: "Retirado",
        year_Experience: 20,
        position_Average: 301,
      },
      {
        id: 2,
        name: "Pedro Luis Lazo",
        position: [{ id: 2, positionName: "Lanzador" }],
        img: "http://localhost:8000/src/logos/pedro_luis_lazo.jpg",
        age: 49,
        teams: ["Pinar del Río"],
        current_Team: "Retirado",
        year_Experience: 20,
        era: 3.22,
        hand: "Derecha",
      },
    ],
  };

  handleOnClick = (id) => {
    this.props.history.push({ pathname: "/player", state: { idPlayer: id } });
  };

  handleOnClickAdd = () => {
    this.props.history.push({ pathname: "/playerForm", state: {} });
  };

  handleOnClickEdit = (player) => {
    console.log("AAAAAA");
    console.log(player);
    this.props.history.push({ pathname: "/playerForm", state: { player } });
  };

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">Jugadores de pelota</h1>
        <Players
          delete={true}
          edit={true}
          players={this.state.players}
          onDelete={this.handleOnClick}
          onEdit={this.handleOnClickEdit}
        />
        <Add text="Agregar jugador" onClick={this.handleOnClickAdd} />
      </Container>
    );
  }
}

export default PlayersGeneral;

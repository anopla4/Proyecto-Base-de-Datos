import React, { Component } from "react";
import { Container } from "react-bootstrap";
import "../../containers/App/App.css";
import Players from "../../components/Players/Players";
import Add from "../../components/Add/Add";

class PlayersGeneral extends Component {
  state = {
    players: [],
  };

  handleOnClick = (id) => {
    this.props.history.push({ pathname: "/player", state: { idPlayer: id } });
  };

  handleOnClickAdd = () => {
    this.props.history.push({ pathname: "/playerForm", state: {} });
  };

  handleOnClickEdit = (player) => {
    this.props.history.push({ pathname: "/playerForm", state: { player } });
  };

  componentDidMount() {
    fetch("https://localhost:44334/api/Player", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ players: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  handleOnDelete = (id, index) => {
    fetch(`https://localhost:44334/api/Player/${id}`, {
      mode: "cors",
      method: "DELETE",
      headers:{"Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token}
    })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });

    let n_players = [...this.state.players];
    n_players.splice(index, 1);

    this.setState({ players: n_players });
  };

  onFormSubmit = (e) => {
    let formElements = e.target.elements;
    const name = formElements.name.value;
    const initials = formElements.initials.value;
    const color = formElements.color.value;

    let team = {
      name,
      initials,
      color,
    };

    let postUrl =
      "https://localhost:44334/api/Team" +
      (this.state.editTeam ? `/${this.state.teamEdit.id}` : "");
    fetch(postUrl, {
      mode: "cors",
      headers: { "Content-Type": "application/json" ,"Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token},
      method: this.state.editTeam ? "PATCH" : "POST",
      body: JSON.stringify(team),
    })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    this.setState({ addTeam: false, editTeam: false });
  };

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">Jugadores de pelota</h1>
        <Players
          playerGeneral={true}
          delete={true}
          edit={true}
          players={this.state.players}
          // onClick={this.handleOnClick}
          onEdit={this.handleOnClickEdit}
          onDelete={this.handleOnDelete}
        />
        <Add text="Agregar jugador" onClick={this.handleOnClickAdd} />
      </Container>
    );
  }
}

export default PlayersGeneral;

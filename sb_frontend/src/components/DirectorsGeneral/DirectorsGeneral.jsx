import React, { Component } from "react";
import { Container } from "react-bootstrap";
import "../../containers/App/App.css";
import Directors from "../../components/Directors/Directors";

class DirectorsGeneral extends Component {
  state = {
    directors: [
      {
        id: 1,
        name: "Víctor Mesa",
        img: "http://localhost:8000/src/logos/victor-mesa.jpg",
        directed_teams: ["Villa Clara", "Matanzas", "Cuba"],
      },
      {
        id: 2,
        name: "Alfonso Urquiola",
        img: "http://localhost:8000/src/logos/Alfonso_Urquiola_Crespo.jpg",
        directed_teams: ["Pinar del Río", "Cuba"],
      },
    ],
  };
  render() {
    return (
      <Container className="list-unstyled">
        <h1 className="mb-5 my-style-header">Directores de béisbol</h1>
        <Directors directors={this.state.directors} />
      </Container>
    );
  }
}

export default DirectorsGeneral;

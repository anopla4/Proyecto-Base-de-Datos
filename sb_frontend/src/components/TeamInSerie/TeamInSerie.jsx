import React, { Component } from "react";
import { Container, Row, Col, Card, Image } from "react-bootstrap";
import "./TeamInSerie.css";
import Players from "../../components/Players/Players";

class TeamInSerie extends Component {
  state = {
    team_name: "Industriales",
    serie_name: "Serie Nacional de Béisbol",
    serie_season: "1994-1995",
    directors: [{ name: "Lázaro Vargas" }],
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
        name: "Frank Camilo Morejón",
        positions: ["Catcher"],
        img: "http://localhost:8000/src/logos/frank-camilo.jpg",
        age: 44,
        teams: ["Industriales"],
        current_team: "Retirado",
        years_of_experience: 17,
        ave: 253,
      },
    ],
  };
  render() {
    const { idTeam, idSerie } = this.props.location.state;
    return (
      <Container>
        <h1 className="mb-5 my-style-header">
          {this.state.team_name} en {this.state.serie_name} (
          {this.state.serie_season})
        </h1>
        <p className="mb-4">
          <h5 style={{ display: "inline" }}>Directores: </h5>
          {this.state.directors.map((dir) => dir.name).join(", ")}.
        </p>
        <Container>
          <Players players={this.state.players} />
          {/* {this.state.players.map((player) => (
            <Card key={player.id} className="player-hover">
              <Card.Header style={{ padding: "0.5%" }}>
                <Row className="row align-items-center">
                  <Col md={1}>
                    <Image
                      fluid
                      roundedCircle
                      src={player.img}
                      alt=""
                      className="custom-circle-image"
                    />
                  </Col>
                  <Col>
                    <h6>{player.name}</h6>
                  </Col>
                  <Col>
                    <p style={{ display: "inline" }}>
                      <h className="header-posiciones-team">Posiciones: </h>
                      {player.positions.join(", ")}.
                    </p>
                  </Col>
                </Row>
              </Card.Header>
            </Card>
          ))} */}
        </Container>
      </Container>
    );
  }
}

export default TeamInSerie;

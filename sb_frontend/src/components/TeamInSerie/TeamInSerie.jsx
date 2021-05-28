import React, { Component } from "react";
import {
  Container,
  Button,
  Row,
  Col,
  Card,
  Image,
  Form,
  Navbar,
  Nav,
} from "react-bootstrap";
import "./TeamInSerie.css";
import Players from "../../components/Players/Players";
import Add from "../../components/Add/Add";
import { PencilSquare } from "react-bootstrap-icons";

class TeamInSerie extends Component {
  state = {
    addPlayer: false,
    team_name: "Industriales",
    serie_name: "Serie Nacional de Béisbol",
    serie_season: "1994-1995",
    directors: [{ name: "Lázaro Vargas" }],
    playerImg: "",
    selectedPlayer: false,
    allPlayers: [
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

  handleOnClickAdd = () => {
    this.setState({ addPlayer: true });
  };

  handleCloseAddPlayer = () => {
    this.setState({ addPlayer: false });
  };

  handleSelectChange = () => {};

  render() {
    const { idTeam, idSerie } = this.props.location.state;
    return (
      <Container>
        <h1 className="mb-5 my-style-header">
          {this.state.team_name} en {this.state.serie_name} (
          {this.state.serie_season})
        </h1>
        <Row>
          <Col>
            <p className="mb-4">
              <h5 style={{ display: "inline" }}>Directores: </h5>
              {this.state.directors.map((dir) => dir.name).join(", ")}.
              <Button
                style={{ padding: "0px" }}
                className={"ml-3 btn-outline-secondary"}
                size={this.props.size}
                variant="light"
              >
                <PencilSquare style={{ width: "100%" }} />
              </Button>
            </p>
            <Players delete={true} players={this.state.players} />
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
            <Add text="Agregar jugador" onClick={this.handleOnClickAdd} />
          </Col>

          {this.state.addPlayer && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form>
                    <Form.Group>
                      <Form.Label>
                        <h5>Seleccione un jugador</h5>
                      </Form.Label>
                    </Form.Group>
                    <Form.Group controlId="name">
                      <Form.Label>Jugador:</Form.Label>
                      <Form.Label>
                        {this.state.selectedPlayer && (
                          <Image src={this.playerImg}></Image>
                        )}
                      </Form.Label>
                      <Form.Control
                        onChange={this.handleSelectChange}
                        as="select"
                        custom
                      >
                        <option>{""}</option>
                        {this.state.allPlayers.map((player) => (
                          <option>{player.name}</option>
                        ))}
                      </Form.Control>
                    </Form.Group>
                    <Form.Group>
                      <Button
                        style={{ float: "right" }}
                        onClick={this.handleCloseAddPlayer}
                        variant="secondary"
                      >
                        Cancelar
                      </Button>
                    </Form.Group>
                  </Form>
                </Nav.Item>
              </Navbar>
            </Col>
          )}
        </Row>
      </Container>
    );
  }
}

export default TeamInSerie;

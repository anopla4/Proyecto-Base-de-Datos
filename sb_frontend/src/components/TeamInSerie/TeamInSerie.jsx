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
  ListGroup,
  ListGroupItem,
} from "react-bootstrap";
import "./TeamInSerie.css";
import Players from "../../components/Players/Players";
import Add from "../../components/Add/Add";
import { List, PencilSquare } from "react-bootstrap-icons";
import { TrashFill } from "react-bootstrap-icons";

class TeamInSerie extends Component {
  state = {
    addPlayer: false,
    addDirector: false,
    team_name: "Industriales",
    serie_name: "Serie Nacional de Béisbol",
    serie_season: "1994-1995",
    directors: [{ name: "Lázaro Vargas" }],
    allDirectors: [{ name: "Lázaro Vargas" }],
    playerImg: "",
    selectedPlayer: false,
    allPlayers: [
      {
        id: 1,
        name: "Alexander Malleta",
        position: ["Primera base"],
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
        position: ["Catcher"],
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
        position: ["Primera base"],
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
        position: ["Catcher"],
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
    this.setState({ addPlayer: true, addDirector: false });
  };

  handleCloseAddPlayer = () => {
    this.setState({ addPlayer: false });
  };
  handleonDeleteDirector = () => {};

  handleAddDirector = () => {
    this.setState({ addDirector: true, addPlayer: false });
  };

  handleCloseAddDirector = () => this.setState({ addDirector: false });

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
            <h5 style={{ display: "inline" }}>Directores: </h5>
            <Row className="mt-2 mb-3">
              <Col md={3}>
                <ListGroup>
                  {this.state.directors.map((dir) => (
                    <ListGroupItem>
                      {dir.name}
                      <Button
                        className="ml-3"
                        style={{ padding: "0px", float: "right" }}
                        onClick={this.state.handleonDeleteDirector}
                        variant="danger"
                      >
                        <TrashFill style={{ width: "100%" }} />
                      </Button>
                    </ListGroupItem>
                  ))}
                </ListGroup>
              </Col>

              <Col md={3} className="mt-2 mb-3">
                <Add
                  className="mt-2"
                  text="Agregar director"
                  onClick={this.handleAddDirector}
                />
              </Col>
            </Row>

            {/* {this.state.directors.map((dir) => dir.name).join(", ")}. */}
            {/* <Button
                style={{ padding: "0px" }}
                className={"ml-3 btn-outline-secondary"}
                variant="light"
              >
                <PencilSquare style={{ width: "100%" }} />
              </Button> */}
            <Row className="mb-3">
              <Col>
                <h5 style={{ display: "inline" }}>Jugadores: </h5>
              </Col>
            </Row>

            <Players
              playerGeneral={false}
              delete={true}
              players={this.state.players}
            />
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
                        className="mr-2"
                        style={{ float: "left" }}
                        variant="primary"
                      >
                        Aceptar
                      </Button>
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
          {this.state.addDirector && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form>
                    <Form.Group>
                      <Form.Label>
                        <h5>Seleccione un director</h5>
                      </Form.Label>
                    </Form.Group>
                    <Form.Group controlId="name">
                      <Form.Label>Director:</Form.Label>
                      {/* <Form.Label>
                        {this.state.selectedPlayer && (
                          <Image src={this.playerImg}></Image>
                        )}
                      </Form.Label> */}
                      <Form.Control
                        onChange={this.handleSelectChange}
                        as="select"
                        custom
                      >
                        <option>{""}</option>
                        {this.state.allDirectors.map((dir) => (
                          <option>{dir.name}</option>
                        ))}
                      </Form.Control>
                    </Form.Group>
                    <Form.Group>
                      <Button
                        className="mr-2"
                        style={{ float: "left" }}
                        variant="primary"
                      >
                        Aceptar
                      </Button>
                      <Button
                        style={{ float: "right" }}
                        onClick={this.handleCloseAddDirector}
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

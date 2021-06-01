import React, { Component } from "react";
import "./Game.css";
import {
  Container,
  Row,
  Col,
  Image,
  Card,
  Nav,
  Table,
  Button,
  Navbar,
  Form,
} from "react-bootstrap";
import Players from "../../components/Players/Players";
import arrow from "../../static/arrow-left.svg";
import Add from "../../components/Add/Add";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";

class Game extends Component {
  state = {
    page: 1,
    addPlayer: false,
    typeTeam: "",
    addChange: false,
    game: {},
    serie: {},
    playersWinnerGame: [],
    playersLoserGame: [],
    playersWinnerSerie: [],
    playersLoserSerie: [],
    winnerChanges: [],
    loserChanges: [],
    positions: [],
  };

  handleOnClick = (p) => {
    this.setState({
      page: p,
      addPlayer: false,
      addChange: false,
      typeTeam: "",
    });
  };

  handleOnClickAddPlayer = (typeTeam) => {
    this.setState({ addPlayer: true, addChange: false, typeTeam: typeTeam });
  };
  handleOnClickAddChange = (typeTeam) => {
    this.setState({ addPlayer: false, addChange: true, typeTeam: typeTeam });
  };
  handleCloseAdd = () => {
    this.setState({ addChange: false, addPlayer: false });
  };

  componentWillMount() {
    this.setState({
      game: this.props.location.state.game,
      serie: this.props.location.state.serie,
    });
    fetch(
      ` https://localhost:44334/api/TeamSeriePlayer/Players/${this.state.game.winerTeamId}/${this.state.serie.id}/${this.state.serie.initDate}/${this.state.serie.endDate}`,
      {
        mode: "cors",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ playersWinnerSerie: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch(
      ` https://localhost:44334/api/TeamSeriePlayer/Players/${this.state.game.loserTeamId}/${this.state.serie.id}/${this.state.serie.initDate}/${this.state.serie.endDate}`,
      {
        mode: "cors",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ playerLoserSerie: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch("https://localhost:44334/api/Position", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ positions: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  componentDidMount() {
    fetch(
      ` https://localhost:44334/api/PlayerGame/${this.state.game.gameId}/WinerTeam`,
      {
        mode: "cors",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ playersWinnerGame: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch(
      ` https://localhost:44334/api/PlayerGame/${this.state.game.gameId}/LoserTeam`,
      {
        mode: "cors",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ playerLoserGame: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch(
      ` https://localhost:44334/api/PlayerChangeGame/${this.state.game.gameId}/WinerTeam`,
      {
        mode: "cors",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ winnerChanges: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch(
      ` https://localhost:44334/api/PlayerChangeGame/${this.state.game.gameId}/LoserTeam`,
      {
        mode: "cors",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ loserChanges: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  onFormSubmitPlayer = (e) => {
    let formElements = e.target.elements;
    const player = formElements.player;
    const playerId = player.children[player.selectedIndex].id;
    const positions = formElements.positions;
    const positionId = positions.children[positions.selectedIndex].id;

    let playerGame = {
      gameId: this.state.game.gameId,
      playerId: playerId,
      positionId: positionId,
    };

    fetch("https://localhost:44334/api/PlayerGame", {
      mode: "cors",
      headers: { "Content-Type": "application/json" },
      method: "POST",
      body: JSON.stringify(playerGame),
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
    this.setState({ addPlayer: false });
  };

  onFormSubmitChange = (e) => {
    let formElements = e.target.elements;
    const playerOut = formElements.changeOut;
    const playerIdOut = playerOut.children[playerOut.selectedIndex].id;
    const playerIn = formElements.changeOut;
    const playerIdIn = playerIn.children[playerIn.selectedIndex].id;
    const positions = formElements.positions;
    const positionId = positions.children[positions.selectedIndex].id;

    let playerChangeGame = {
      gameId: this.state.game.gameId,
      playerIdOut: playerIdOut,
      positionIdOut: positionId,
      playerIdIn: playerIdIn,
      positionIdIn: positionId,
    };

    fetch("https://localhost:44334/api/PlayerChangeGame", {
      mode: "cors",
      headers: { "Content-Type": "application/json" },
      method: "POST",
      body: JSON.stringify(playerChangeGame),
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
    this.setState({ addPlayer: false });
  };

  handleOnDeletePlayer = (player, index, h) => {
    fetch(
      `https://localhost:44334/api/Player/${this.state.game.gameId}/${this.state.game.player.playerId}/${this.state.game.player.positionId}`,
      {
        mode: "cors",
        method: "DELETE",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    if (h === "winner") {
      let n_winnerPlayers = [...this.state.playersWinnerGame];
      n_winnerPlayers.splice(index, 1);
      this.setState({ playersWinnerGame: n_winnerPlayers });
    } else {
      let n_loserPlayers = [...this.state.playersLoserGame];
      n_loserPlayers.splice(index, 1);
      this.setState({ playersLoserGame: n_loserPlayers });
    }
  };

  handleOnDeleteChange = (change, index, h) => {
    fetch(
      `https://localhost:44334/api/Player/${this.state.game.gameId}/${change.playerIdIn}/${change.positionIdIn}/${change.playerIdOut}/${change.positionIdOut}`,
      {
        mode: "cors",
        method: "DELETE",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    if (h === "winner") {
      let n_winnerChanges = [...this.state.winnerChanges];
      n_winnerChanges.splice(index, 1);
      this.setState({ winnerChanges: n_winnerChanges });
    } else {
      let n_loserChanges = [...this.state.loserChanges];
      n_loserChanges.splice(index, 1);
      this.setState({ loserChanges: n_loserChanges });
    }
  };

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">
          {this.state.game.winerTeam.name}-{this.state.game.loserTeam.name}
        </h1>
        <Row className="align-items-center">
          <Col className="text-center text-md-right">
            <Image
              style={{ width: "25%" }}
              fluid
              src={`https://localhost:44334/${this.state.game.winerTeam.imgPath}`}
              alt=""
            />
          </Col>
          <Col className="text-center text-md-center bold score" md={2}>
            {this.state.game.inFavorCarrers} - {this.state.game.againstCarrers}
          </Col>
          <Col className="text-center text-md-left">
            <Image
              style={{ width: "25%" }}
              fluid
              src={`https://localhost:44334/${this.state.game.loserTeam.imgPath}`}
              alt=""
            />
          </Col>
        </Row>
        <Row className="justify-content-center mt-3">
          <p style={{ display: "inline" }}>
            <Container className="bold">Lanzador ganador: </Container>{" "}
            {this.state.game.pitcherWiner.name}.
          </p>
          <p style={{ display: "inline" }}>
            <Container className="bold">Lanzador perdedor: </Container>{" "}
            {this.state.game.pitcherLoser.name}.
          </p>
        </Row>
        <Row>
          <Col>
            <Card style={{ width: "100%" }}>
              <Card.Header>
                <Nav variant="tabs" defaultActiveKey={1}>
                  <Nav.Item onClick={() => this.handleOnClick(1)} key={1}>
                    <Nav.Link>Jugadores</Nav.Link>
                  </Nav.Item>
                  <Nav.Item onClick={() => this.handleOnClick(2)} key={2}>
                    <Nav.Link>Cambios</Nav.Link>
                  </Nav.Item>
                </Nav>
              </Card.Header>
              <Card.Body>
                {this.state.page === 1 && (
                  <Row style={{ fontSize: "10px" }}>
                    <Col>
                      <h6>Ganador</h6>
                      {this.state.playersWinnerGame.map((player, index) => (
                        <Card key={player.id} className="mb-2">
                          <Card.Header style={{ padding: "0.5%" }}>
                            <Row className="row align-items-center">
                              <Col md={1}>
                                <Image
                                  fluid
                                  roundedCircle
                                  src={`https://localhost:44334/${player.imgPath}`}
                                  style={{ height: "85px" }}
                                  alt=""
                                  className="custom-circle-image"
                                />
                              </Col>
                              <Col>
                                <h5>{player.name}</h5>
                                <h6>{player.position.positionName}</h6>
                              </Col>
                              <Col>
                                <DeleteEdit
                                  onDelete={() =>
                                    this.state.handleOnDeletePlayer(
                                      player,
                                      index,
                                      "winner"
                                    )
                                  }
                                />
                              </Col>
                            </Row>
                          </Card.Header>
                        </Card>
                      ))}
                      <Add
                        text="Agregar jugador"
                        onClick={() => this.handleOnClickAddPlayer("winner")}
                      />
                    </Col>
                    <Col>
                      <h6>Perdedor</h6>
                      {this.state.playersLoserGame.map((player, index) => (
                        <Card key={player.id} className="mb-2">
                          <Card.Header style={{ padding: "0.5%" }}>
                            <Row className="row align-items-center">
                              <Col md={1}>
                                <Image
                                  fluid
                                  roundedCircle
                                  src={`https://localhost:44334/${player.imgPath}`}
                                  style={{ height: "85px" }}
                                  alt=""
                                  className="custom-circle-image"
                                />
                              </Col>
                              <Col>
                                <h5>{player.name}</h5>
                                <h6>{player.position.positionName}</h6>
                              </Col>
                              <Col>
                                <DeleteEdit
                                  onDelete={() =>
                                    this.state.handleOnDeletePlayer(
                                      player,
                                      index,
                                      "loser"
                                    )
                                  }
                                />
                              </Col>
                            </Row>
                          </Card.Header>
                        </Card>
                      ))}
                      <Add
                        text="Agregar jugador"
                        onClick={() => this.handleOnClickAddPlayer("loser")}
                      />
                    </Col>
                  </Row>
                )}
                {this.state.page === 2 && (
                  <Row>
                    <Col>
                      <h6>Ganador</h6>
                      <Table striped hover>
                        <thead>
                          <th>Jugador</th>
                          <th></th>
                          <th>Cambio</th>
                          <th></th>
                        </thead>
                        <tbody>
                          {this.state.winnerChanges.map((change, index) => (
                            <tr>
                              <td>{change.playerPositionOut.name}</td>
                              <td>
                                <Image src={arrow} />
                              </td>
                              <td>{change.playerPositionIn.name}</td>
                              <DeleteEdit
                                delete={true}
                                onDelete={() =>
                                  this.handleOnDeleteChange(
                                    change,
                                    index,
                                    "winner"
                                  )
                                }
                              />
                            </tr>
                          ))}
                        </tbody>
                      </Table>
                      <Add
                        text="Agregar cambio"
                        onClick={() => this.handleOnClickAddChange("winner")}
                      />
                    </Col>
                    <Col>
                      <h6>Perdedor</h6>
                      <Table striped hover>
                        <thead>
                          <th>Jugador</th>
                          <th></th>
                          <th>Cambio</th>
                          <th></th>
                        </thead>
                        <tbody>
                          {this.state.loserChanges.map((change, index) => (
                            <tr>
                              <td>{change.playerPositionOut.name}</td>
                              <td>
                                <Image src={arrow} />
                              </td>
                              <td>{change.playerPositionIn.name}</td>
                              <DeleteEdit
                                delete={true}
                                onDelete={() =>
                                  this.handleOnDeleteChange(
                                    change,
                                    index,
                                    "loser"
                                  )
                                }
                              />
                            </tr>
                          ))}
                        </tbody>
                      </Table>
                      <Add
                        text="Agregar cambio"
                        onClick={() => this.handleOnClickAddChange("loser")}
                      />
                    </Col>
                  </Row>
                )}
              </Card.Body>
            </Card>
          </Col>
          {this.state.addPlayer && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form onSubmit={this.onFormSubmitPlayer}>
                    <Form.Group controlId="player">
                      <Form.Label>Jugador:</Form.Label>
                      {this.state.typeTeam === "winner" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersWinnerSerie.map((player) => (
                            <option id={player.id}>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                      {this.state.typeTeam === "loser" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersLoserSerie.map((player) => (
                            <option id={player.id}>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                    </Form.Group>
                    <Form.Group controlId="positions">
                      <Form.Label>Posición:</Form.Label>
                      <Form.Control as="select" custom>
                        <option>{""}</option>
                        {this.state.positions.map((pos) => (
                          <option id={pos.id}>{pos.positionName}</option>
                        ))}
                      </Form.Control>
                    </Form.Group>
                    <Form.Group>
                      <Button
                        className="mr-2"
                        style={{ float: "left" }}
                        variant="primary"
                        type="submit"
                      >
                        Aceptar
                      </Button>
                      <Button
                        style={{ float: "right" }}
                        onClick={this.handleCloseAdd}
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
          {this.state.addChange && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form onSubmit={this.onFormSubmitChange}>
                    <Form.Group controlId="changeOut">
                      <Form.Label>Jugador que salió:</Form.Label>
                      {this.state.typeTeam === "winner" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersWinnerSerie.map((player) => (
                            <option id={player.id}>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                      {this.state.typeTeam === "loser" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersLoserSerie.map((player) => (
                            <option id={player.id}>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                    </Form.Group>
                    <Form.Group controlId="changeIn">
                      <Form.Label>Jugador que entró:</Form.Label>
                      {this.state.typeTeam === "winner" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersWinnerSerie.map((player) => (
                            <option id={player.id}>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                      {this.state.typeTeam === "loser" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersLoserSerie.map((player) => (
                            <option id={player.id}>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                    </Form.Group>
                    <Form.Group controlId="positions">
                      <Form.Label>Posición:</Form.Label>
                      <Form.Control as="select" custom>
                        <option>{""}</option>
                        {this.state.positions.map((pos) => (
                          <option id={pos.id}>{pos.positionName}</option>
                        ))}
                      </Form.Control>
                    </Form.Group>
                    <Form.Group>
                      <Button
                        className="mr-2"
                        style={{ float: "left" }}
                        variant="primary"
                        type="submit"
                      >
                        Aceptar
                      </Button>
                      <Button
                        style={{ float: "right" }}
                        onClick={this.handleCloseAdd}
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

export default Game;

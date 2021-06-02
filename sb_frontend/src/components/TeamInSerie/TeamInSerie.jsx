import React, { Component } from "react";
import {
  Container,
  Button,
  Row,
  Col,
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
import { TrashFill } from "react-bootstrap-icons";
import isLoggedIn from "../utils";

class TeamInSerie extends Component {
  state = {
    addPlayer: false,
    addDirector: false,
    serie: {},
    team: {},
    allDirectors: [],
    directors: [],
    playerImg: "",
    selectedPlayer: false,
    allPlayers: [],
    players: [],
  };

  formatDate = (date) => {
    let d = new Date(date);
    return `${d.getFullYear()}-${d.getMonth() + 1}-${d.getDate()}`;
  };

  componentWillMount() {
    fetch("https://localhost:44334/api/Director", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ allDirectors: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch(`https://localhost:44334/api/Player`, { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ allPlayers: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    this.setState({
      team: this.props.location.state.team,
      serie: this.props.location.state.serie,
    });
  }

  componentDidMount() {
    fetch(
      `https://localhost:44334/api/TeamSerieDirector/Directors/${
        this.state.serie.id
      }/${this.formatDate(this.state.serie.initDate)}/${this.formatDate(
        this.state.serie.endDate
      )}/${this.state.team.id}`,
      { mode: "cors" }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ directors: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });

    fetch(
      `https://localhost:44334/api/TeamSeriePlayer/Players/${
        this.state.team.id
      }/${this.state.serie.id}/${this.formatDate(
        this.state.serie.initDate
      )}/${this.formatDate(this.state.serie.endDate)}`,
      { mode: "cors" }
    )
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

  handleOnClickAdd = () => {
    this.setState({ addPlayer: true, addDirector: false });
  };

  handleCloseAddPlayer = () => {
    this.setState({ addPlayer: false });
  };
  handleOnDeleteDirector = (idD, index) => {
    fetch(
      `https://localhost:44334/api/TeamSerieDirector/${idD}/${this.state.serie.id}/
      ${this.state.serie.initDate}/${this.state.serie.endDate}/${this.state.team.id}`,
      { mode: "cors", method: "DELETE",headers:{"Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token} }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ directors: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });

    let n_directors = [...this.state.directors];
    n_directors.splice(index, 1);

    this.setState({ directors: n_directors });
  };

  handleOnDeletePlayer = (idP, index) => {
    fetch(
      `https://localhost:44334/api/TeamSeriePlayer/${idP}/${this.state.serie.id}/
      ${this.state.serie.initDate}/${this.state.serie.endDate}/${this.state.team.id}`,
      { mode: "cors", method: "DELETE",headers:{"Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token} }
    )
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

    let n_players = [...this.state.players];
    n_players.splice(index, 1);

    this.setState({ players: n_players });
  };

  handleOnClickAddDirector = () => {
    this.setState({ addDirector: true, addPlayer: false });
  };

  onFormSubmit = (e) => {
    let formElements = e.target.elements;
    if (this.state.addDirector) {
      console.log("AAAAAAAAAAAAAAAAAAAAAAAA");
      console.log(this.state.team);
      const director = formElements.director;
      const directorId = director
        ? director.children[director.selectedIndex].id
        : "";
      console.log(directorId);
      let item = {
        directorId: directorId,
        serieId: this.state.serie.id,
        serieInitDate: this.state.serie.initDate,
        serieEndDate: this.state.serie.endDate,
        teamSerieId: this.state.team.id,
      };
      fetch("https://localhost:44334/api/TeamSerieDirector", {
        mode: "cors",
        headers: { "Content-Type": "application/json","Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token },
        method: "POST",
        body: JSON.stringify(item),
      })
        .then((response) => {
          if (!response.ok) {
            throw Error(response.statusText);
          }
          return response.json();
        })
        .catch(function (error) {
          console.log(
            "Hubo un problema con la petición Fetch:" + error.message
          );
        });
      this.setState({
        addDirector: false,
      });
    } else {
      const player = formElements.player;
      const playerId = player ? player.children[player.selectedIndex].id : "";
      let item = {
        playerId: playerId,
        serieId: this.state.serie.id,
        serieInitDate: this.state.serie.initDate,
        serieEndDate: this.state.serie.endDate,
        teamsSerieId: this.state.team.id,
      };
      fetch("https://localhost:44334/api/TeamSeriePlayer", {
        mode: "cors",
        headers: { "Content-Type": "application/json", "Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token},
        method: "POST",
        body: JSON.stringify(item),
      })
        .then((response) => {
          if (!response.ok) {
            throw Error(response.statusText);
          }
          return response.json();
        })
        .catch(function (error) {
          console.log(
            "Hubo un problema con la petición Fetch:" + error.message
          );
        });
      this.setState({
        addPlayer: false,
        addDirector: false,
      });
    }
  };

  handleCloseAddDirector = () => this.setState({ addDirector: false });

  handleOnChange = (e) => {
    e.preventDefault();
    let index = e.target.selectedIndex;
    let el = e.target.childNodes[index];
    let option = el.getAttribute("id");
    this.setState((prevState) => ({
      selectedPositions: [...prevState.selectedPositions, option],
    }));
  };

  render() {
    const { team, serie } = this.props.location.state;
    return (
      <Container>
        <h1 className="mb-5 my-style-header">
          {this.state.team.name} en {this.state.serie.name} (
          {this.formatDate(this.state.serie.initDate)}/
          {this.formatDate(this.state.serie.endDate)})
        </h1>
        <Row>
          <Col>
            <Row>
              <Col>
                <h5 style={{ display: "inline" }}>Directores: </h5>
              </Col>
              <Col md={3} className="mt-2 mb-3">
                <Add
                  // className="mt-2"
                  text="Agregar director"
                  onClick={this.handleOnClickAddDirector}
                />
              </Col>
            </Row>

            <Row className="mt-2 mb-3">
              <Col md={3}>
                <ListGroup>
                  {this.state.directors.map((dir, index) => (
                    <ListGroupItem>
                      {dir.name}
                      {
                        isLoggedIn() &&
                        <Button
                          className="ml-3"
                          style={{ padding: "0px", float: "right" }}
                          onClick={() =>
                            this.handleOnDeleteDirector(dir.id, index)
                          }
                          variant="danger"
                        >
                          <TrashFill style={{ width: "100%" }} />
                        </Button>
                      }
                    </ListGroupItem>
                  ))}
                </ListGroup>
              </Col>
            </Row>
            <Row className="mb-3">
              <Col>
                <h5 style={{ display: "inline" }}>Jugadores: </h5>
              </Col>
            </Row>

            <Players
              playerGeneral={false}
              delete={true}
              onDelete={this.handleOnDeletePlayer}
              players={this.state.players}
            />
            <Add text="Agregar jugador" onClick={this.handleOnClickAdd} />
          </Col>

          {this.state.addPlayer && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form onSubmit={this.onFormSubmit}>
                    <Form.Group>
                      <Form.Label>
                        <h5>Seleccione un jugador</h5>
                      </Form.Label>
                    </Form.Group>
                    <Form.Group controlId="player">
                      <Form.Label>Jugador:</Form.Label>
                      <Form.Label>
                        {this.state.selectedPlayer && (
                          <Image
                            src={`https://localhost:44334/${this.playerImg}`}
                          ></Image>
                        )}
                      </Form.Label>
                      <Form.Control
                        onChange={this.handleOnChange}
                        as="select"
                        custom
                      >
                        <option>{""}</option>
                        {this.state.allPlayers.map((player) => (
                          <option id={player.id}>{player.name}</option>
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
                  <Form onSubmit={this.onFormSubmit}>
                    <Form.Group>
                      <Form.Label>
                        <h5>Seleccione un director</h5>
                      </Form.Label>
                    </Form.Group>
                    <Form.Group controlId="director">
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
                          <option id={dir.id}>{dir.name}</option>
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

import React, { Component } from "react";
import { Form, Button, Row, Col, Container } from "react-bootstrap";
import "./GameForm.css";

class GameForm extends Component {
  state = {
    edit: false,
    changed: false,
    pitchers: [{ name: "Rivero" }, { name: "Pedro Luis Lazo" }],
    teams: [],
    series: [],
  };
  //   onChange = (e) => {
  //     e.preventDefault();
  //     this.setState((prevState) => ({
  //       changed: true,
  //       selectedPositions: [...prevState.selectedPositions, e.target.value],
  //     }));
  //   };

  componentDidMount() {
    if (this.props.location.state.game) {
      this.setState({ edit: true });
    }
  }

  componentWillMount() {
    fetch("https://localhost:44334/api/Team", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ teams: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch("https://localhost:44334/api/Serie", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ series: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  onFormSubmit = (e) => {
    let formElements = e.target.elements;
    const name = formElements.name.value;
    const initDate = this.state.edit
      ? this.props.location.state.serie.initDate
      : this.formatDate(new Date(formElements.initDate.value));
    const endDate = this.state.edit
      ? this.props.location.state.serie.endDate
      : this.formatDate(new Date(formElements.endDate.value));
    const serie = formElements.serie;
    const serieId = serie.children[serie.selectedIndex].id;
    const winner = formElements.winner;
    const winnerId = winner.children[winner.selectedIndex].id;
    const loser = formElements.loser;
    const winner_pitcher = winner.children[winner_pitcher.selectedIndex].id;
    const winner_pitcherId = formElements.winner_pitcher;
    const loserId = loser.children[loser.selectedIndex].id;
    const runs_against = formElements.runs_against.value;
    const runs_in_favor = formElements.runs_in_favor.value;

    let game = {
      name,
      initDate,
      endDate,
    };
    let postUrl =
      "https://localhost:44334/api/Game" +
      (this.state.edit
        ? `/${this.props.location.state.serie.id}/${serie.initDate}/${serie.endDate}`
        : "");
    fetch(postUrl, {
      mode: "cors",
      headers: { "Content-Type": "application/json" },
      method: this.state.edit ? "PATCH" : "POST",
      body: JSON.stringify(serie),
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
    this.props.history.push({ pathname: "/series", state: { edited: true } });
  };

  render() {
    const {
      id,
      winnerTeam,
      loserTeam,
      gameDate,
      gameTime,
      serie,
      winner_pitcher,
      loser_pitcher,
      InFavorCarrers,
      AgaintsCarrers,
    } = {
      ...this.props.location.state.game,
    };
    return (
      <Container alignSelf="center" className="mt-4">
        <h1 className="mb-5 my-style-header">Juego</h1>

        <Col className="center">
          <Form
            onSubmit={this.onFormSubmit}
            style={{ width: "70%", alignItems: "center" }}
          >
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="serie">
                  <Form.Label>Serie:</Form.Label>
                  <Form.Control
                    defaultValue={
                      serie
                        ? serie.name +
                          " (" +
                          serie.initDate +
                          " - " +
                          serie.endDate +
                          ")"
                        : ""
                    }
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.series.map((serie) => (
                      <option id={serie.id}>
                        {serie.name} (
                        {
                          new Date(serie.initDate)
                            .toLocaleString()
                            .split(",")[0]
                        }{" "}
                        -{" "}
                        {new Date(serie.endDate).toLocaleString().split(",")[0]}
                        )
                      </option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="gameDate">
                  <Form.Label>Fecha de incio:</Form.Label>
                  <Form.Control
                    defaultValue={
                      gameDate
                        ? new Date(gameDate).toISOString().substr(0, 10)
                        : ""
                    }
                    disabled={this.state.edit ? true : false}
                    type="date"
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="gameTime">
                  <Form.Label>Hora:</Form.Label>
                  <Form.Control
                    defaultValue={gameTime ? gameTime : ""}
                    type="text"
                    name="gameTime"
                  />
                  <Form.Text id="helpTime" muted>
                    El formato de la hora debe ser hh:mm.
                  </Form.Text>
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group
                  style={{ width: "100%" }}
                  controlId="winner_pitcher"
                >
                  <Form.Label>Lanzador ganador:</Form.Label>
                  <Form.Control
                    defaultValue={winner_pitcher ? winner_pitcher.name : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.pitchers.map((pitcher) => (
                      <option id={pitcher.id}>{pitcher.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group
                  style={{ width: "100%" }}
                  controlId="winner_pitcher"
                >
                  <Form.Label>Lanzador perdedor:</Form.Label>
                  <Form.Control
                    defaultValue={loser_pitcher ? loser_pitcher.name : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.pitchers.map((pitcher) => (
                      <option id={pitcher.id}>{pitcher.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group controlId="runs_in_favor">
                  <Form.Label>Carreras a favor:</Form.Label>
                  <Form.Control
                    defaultValue={InFavorCarrers ? InFavorCarrers : ""}
                    type="numeric"
                    name="runs_in_favor"
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="runs_against">
                  <Form.Label>Carreras en contra:</Form.Label>
                  <Form.Control
                    defaultValue={AgaintsCarrers ? AgaintsCarrers : ""}
                    type="numeric"
                    name="runs_against"
                  />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="winner">
                  <Form.Label>Ganador:</Form.Label>
                  <Form.Control
                    defaultValue={winnerTeam ? winnerTeam.name : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.teams.map((team) => (
                      <option id={team.id}>{team.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="loser">
                  <Form.Label>Perdedor:</Form.Label>
                  <Form.Control
                    defaultValue={loserTeam ? loserTeam.name : ""}
                    as="select"
                    custom
                  >
                    <option>{""}</option>
                    {this.state.teams.map((team) => (
                      <option id={team.id}>{team.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
            </Row>
            <Button
              style={{ float: "right" }}
              className="mt-3 ml-3"
              variant="secondary"
              type="reset"
            >
              Reiniciar
            </Button>
            <Button
              style={{ float: "right" }}
              className="mt-3 ml-3"
              variant="primary"
              type="submit"
            >
              Aceptar
            </Button>
          </Form>
        </Col>
      </Container>
    );
  }
}

export default GameForm;

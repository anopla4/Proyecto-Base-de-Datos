import React, { Component } from "react";
import "./Allstarteams.css";
import {
  Accordion,
  Card,
  Row,
  CardDeck,
  Table,
  Col,
  Container,
  Button,
  Image,
} from "react-bootstrap";
import star from "../../static/star.png";
import chevron from "../../static/chevron-compact-down.svg";

class AllStarTeams extends Component {
  state = {
    series: [],
  };

  componentDidMount() {
    fetch("https://localhost:44334/api/StarPositionPlayerSerie", {
      mode: "cors",
    })
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
    fetch("https://localhost:44334/api/StarPositionPlayerSerie", {
      mode: "cors",
    })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ allstarteams: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">
          Equipos "TODOS ESTRELLAS"{" "}
          {/* <img src={star} width="30" height="30" alt="" /> */}
        </h1>
        <Accordion className="mb-3">
          {this.state.series.map((team) => (
            <Card key={team.serie.id}>
              <Card.Header>
                <Row>
                  <Col>
                    <Card.Title className="my-style-card-header">
                      {team.serie.name}
                    </Card.Title>
                    <Card.Subtitle style={{ color: "midnightblue" }}>
                      {
                        new Date(team.serie.serieInitDate)
                          .toLocaleString()
                          .split(",")[0]
                      }
                      -
                      {
                        new Date(team.serie.serieEndDate)
                          .toLocaleString()
                          .split(",")[0]
                      }
                    </Card.Subtitle>
                  </Col>
                  <Col md={2}>
                    <Accordion.Toggle
                      as={Button}
                      variant="link"
                      eventKey={team.serie.id}
                      className="my-button star"
                    >
                      <img src={star} width="30" height="30" alt="" />
                    </Accordion.Toggle>
                  </Col>
                </Row>
              </Card.Header>
              <Accordion.Collapse eventKey={team.serie.id}>
                <Card.Body>
                  <Table>
                    {team.map((player) => (
                      <tr>
                        <td>{player.name}</td>
                        <td>{player.position}</td>
                      </tr>
                    ))}
                  </Table>
                </Card.Body>
              </Accordion.Collapse>
            </Card>
          ))}
        </Accordion>
      </Container>
    );
  }
}

export default AllStarTeams;

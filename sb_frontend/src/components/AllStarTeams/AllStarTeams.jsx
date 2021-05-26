import React, { Component } from "react";
import "./Allstarteams.css";
import { Card, CardDeck, Table, Col, Container } from "react-bootstrap";
import star from "../../static/star.png";

class AllStarTeams extends Component {
  state = {
    series: [
      {
        id: 1,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1994-1995",
        players: [
          {
            name: "Alexander Malleta",
            team: "Industriales",
            position: "Primera base",
          },
          {
            name: "Frank Camilo Morejón",
            team: "Industriales",
            position: "Catcher",
          },
        ],
      },
      {
        id: 2,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1996-1997",
        players: [
          {
            name: "Alexander Malleta",
            team: "Industriales",
            position: "Primera base",
          },
          {
            name: "Frank Camilo Morejón",
            team: "Industriales",
            position: "Catcher",
          },
        ],
      },
      {
        id: 3,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1997-1998",
        players: [
          {
            name: "Alexander Malleta",
            team: "Industriales",
            position: "Primera base",
          },
          {
            name: "Frank Camilo Morejón",
            team: "Industriales",
            position: "Catcher",
          },
        ],
      },
      {
        id: 4,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1998-1999",
        players: [
          {
            name: "Lázaro Blanco",
            team: "Granma",
            position: "Primera base",
          },
          {
            name: "Yulieski Gourriel",
            team: "Industriales",
            position: "Tercera base",
          },
        ],
      },
      {
        id: 5,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        season: "1999-2000",
        players: [
          {
            name: "Tabares",
            team: "Industriales",
            position: "Jardinero Central",
          },
          {
            name: "Rivero",
            team: "Industriales",
            position: "Pitcher",
          },
        ],
      },
    ],
  };
  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">
          Equipos "TODOS ESTRELLAS"{" "}
          <img src={star} width="30" height="30" alt="" />
        </h1>
        <CardDeck>
          {this.state.series.map((serie) => (
            <Col md="4">
              <Card
                border="info"
                key={serie.id}
                text={"black"}
                className="mb-3 my-style-card active_hover"
              >
                <Card.Header>
                  <Card.Title className="my-style-card-header">
                    {serie.name}
                  </Card.Title>
                  <Card.Subtitle style={{ color: "midnightblue" }}>
                    {serie.season}
                  </Card.Subtitle>
                </Card.Header>
                <Card.Body>
                  <Table>
                    {serie.players.map((player) => (
                      <tr>
                        <td>{player.name}</td>
                        <td>{player.team}</td>
                      </tr>
                    ))}
                  </Table>
                </Card.Body>
              </Card>
            </Col>
          ))}
        </CardDeck>
      </Container>
    );
  }
}

export default AllStarTeams;
import React, { Component } from "react";
import { Accordion, Card, Col, Row, Image, Button } from "react-bootstrap";
import "./Player.css";
import chevron from "../../static/chevron-compact-down.svg";
class Player extends Component {
  state = {
    player: {
      id: 1,
      name: "Alexander Malleta",
      position: "Primera base",
      img: "http://localhost:8000/src/logos/malleta.jpg",
      age: 44,
      teams: ["Industriales", "Metropolitanos"],
      current_team: "Retirado",
      years_of_experience: 20,
    },
  };
  render() {
    return;
  }
}

export default Player;

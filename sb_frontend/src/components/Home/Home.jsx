import React, { Component } from "react";
import { Carousel } from "react-bootstrap";
import "./Home.css";

class Home extends Component {
  state = {
    image_src: [
      "http://localhost:8000/src/logos/home-4.jpg",
      "http://localhost:8000/src/logos/home-1.jpg",
      "http://localhost:8000/src/logos/home-2.jpg",
      "http://localhost:8000/src/logos/home-3.jpg",
    ],
  };
  render() {
    return (
      <Carousel className="carousel" fade>
        {this.state.image_src.map((src) => (
          <Carousel.Item className="item">
            <img className="d-block w-100" src={src} alt="" />
          </Carousel.Item>
        ))}
      </Carousel>
    );
  }
}

export default Home;

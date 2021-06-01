import React, { Component } from "react";
import { Carousel } from "react-bootstrap";
import "./Home.css";
import home1 from "../../static/home-4.jpg";
import home2 from "../../static/home-1.jpg";
import home3 from "../../static/home-2.jpg";
import home4 from "../../static/home-3.jpg";

class Home extends Component {
  state = {
    image_src: [home1, home2, home3, home4],
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

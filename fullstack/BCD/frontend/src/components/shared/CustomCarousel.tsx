import { Carousel } from "react-bootstrap";
import { IBusinessPhotoProp } from "../../types/types";

const CustomCarousel: React.FC<IBusinessPhotoProp> = ({ businessPhotos }) => {
  //console.log("businessPhotos", businessPhotos);
  return (
    <Carousel>
      {businessPhotos.length > 0 ? businessPhotos.map((photo, index) => {
        return (
          <Carousel.Item key={index}>
            <img src={`/images/business/${photo.url}`} className="business-img-rounded" />
          </Carousel.Item>
        ) 
      }) : 
      <Carousel.Item>
        <img src={`/images/business/default-3.avif`} className="business-img-rounded" />
      </Carousel.Item>}

      {/* <Carousel.Item>
        <img src="/images/business-1.png" />
        <Carousel.Caption>
          <h3>Second slide label</h3>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img src="/images/business-2.png" />
        <Carousel.Caption>
          <h3>Third slide label</h3>
          <p>
            Praesent commodo cursus magna, vel scelerisque nisl consectetur.
          </p>
        </Carousel.Caption>
      </Carousel.Item> */}
    </Carousel>
  );
};

export default CustomCarousel;

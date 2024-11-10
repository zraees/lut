import { useLocation } from "react-router-dom";
import CustomMap from "../map/CustomMap";
import CustomCarousel from "../shared/CustomCarousel";
import BusinessOverview from "./BusinessOverview";
import { Tab, Tabs } from "react-bootstrap";
import { useState } from "react";
import BusinessReviews from "./BusinessReviews";

const BusinessDetail = () => {
  const location = useLocation();
  const business = location.state;
  const [key, setKey] = useState("tabOverview"); // Manage the active tab

  //console.log('business.latitude', business.latitude, business.longitude)
  return (
    <div className="container ">
      <h1 className="display-6">Business Details</h1>

      <div className="row flex-lg-row g-1 py-4">
        <div className="col-10 col-sm-8 col-lg-6">
          <CustomCarousel
            businessPhotos={business?.businessPhotos}
          ></CustomCarousel>
        </div>
        <div className="col-lg-6">
          <Tabs
            activeKey={key}
            onSelect={(k) => setKey(k)}
            id="controlled-tab-example"
          >
            <Tab eventKey="tabOverview" title="Overview">
              <BusinessOverview business={business}></BusinessOverview>
            </Tab>
            <Tab eventKey="tabReviews" title="Reviews">
              <BusinessReviews businessReviews={business.businessReviews}></BusinessReviews>
            </Tab>
          </Tabs>
        </div>
      </div>

      <div className="row justify-content-md-center">
        <div className="col-md-auto map-container">
          <CustomMap
            latitude={business.latitude}
            longitude={business.longitude}
          ></CustomMap>
        </div>
      </div>
    </div>
  );
};

export default BusinessDetail;

import { SlLocationPin } from "react-icons/sl";
import { IBusinessOverviewProp } from "../../types/types";
import { FcClock } from "react-icons/fc";
import { SiWebtrees } from "react-icons/si";
import { FaPhoneAlt } from "react-icons/fa";

const BusinessOverview: React.FC<IBusinessOverviewProp> = ({ business }) => {
  return (
    <div className="g-1 py-2">
      <h1 className="display-5 fw-bold text-body-emphasis lh-1 mb-3">
        {business.name}
      </h1>
      <p className="lead">{business.description}</p>
      <div className="d-grid gap-2 d-md-flex justify-content-md-start"></div>

      <div className="d-flex mb-2">
        <div className="p-1"><SlLocationPin /></div>
        <div className="p-1">{business.address}</div>
      </div>
      
      <div className="d-flex mb-2">
        <div className="p-1"><FcClock /></div>
        <div className="p-1">{business.hoursOfOperation}</div>
      </div>
      
      <div className="d-flex mb-2">
        <div className="p-1"><SiWebtrees /></div>
        <div className="p-1"><a href={business.website} target="_blank">{business.website}</a></div>
      </div>
      
      <div className="d-flex mb-2">
        <div className="p-1"><FaPhoneAlt /></div>
        <div className="p-1">{business.phoneNumber}</div>
      </div>
      
    </div>
  );
};

export default BusinessOverview;

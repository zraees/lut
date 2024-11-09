import { IBusinessCardProps } from "../../types";
import { SlLocationPin } from "react-icons/sl";

const BusinessCard: React.FC<IBusinessCardProps> = ({ business, redirectToDetail }) => {
  
  const imgUrl = business?.businessPhotos[0]?.url ?? "default-3.avif";

  return (
      <div className="card shadow-sm business-card" onClick={ () => redirectToDetail(business) }>
        <img
          className="bd-placeholder-img card-img-top"
          width="100%"
          height="225"
          role="img"
          aria-label="Placeholder: Thumbnail"
          src={`/images/business/${imgUrl}`}
        />
        <div className="card-body">
          <p className="card-text">
            <b>{business.name}</b>
            <br />
            {business.description}
          </p>
          <div className="d-flex justify-content-between align-items-center">
            <div className="btn-group">
              <button
                type="button"
                className="btn btn-sm btn-outline-secondary"
              >
                <SlLocationPin /> {business.location}
                {/* {business?.category?.name??"category"} */}
              </button>
              {/* <button type="button" className="btn btn-sm btn-outline-secondary">
            </button> */}
            </div>
            <small className="text-body-secondary">9 mins</small>
          </div>
        </div>
      </div>
  );
};

export default BusinessCard;

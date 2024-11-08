import { IBusinessCardProps } from "../../types";

const BusinessCard: React.FC<IBusinessCardProps> = ({ business }) => {
  
  //console.log('business?.businessPhotos',business?.businessPhotos[0]?.url??"default.jpg");
  const imgUrl = business?.businessPhotos[0]?.url??"default-3.avif";
  
  return (
    <div className="card shadow-sm business-card">
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
          <b>{business.name}</b><br/> 
          {business.description}
        </p>
        <div className="d-flex justify-content-between align-items-center">
          <div className="btn-group">
            <button type="button" className="btn btn-sm btn-outline-secondary">
              {business?.category?.name??"category"}
            </button>
            <button type="button" className="btn btn-sm btn-outline-secondary">
              {business.location}
            </button>
          </div>
          <small className="text-body-secondary">9 mins</small>
        </div>
      </div>
    </div>
  );
};

export default BusinessCard;

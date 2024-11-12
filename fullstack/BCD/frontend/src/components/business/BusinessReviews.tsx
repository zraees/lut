import { MdOutlineRateReview } from "react-icons/md";
import { IBusinessReviewsProp } from "../../types/types";

const BusinessReviews: React.FC<IBusinessReviewsProp> = ({ businessReviews }) => {

  return (
    <div className="g-1 py-2">
      <div className="text-center py-2">
        <button type="button" className="btn btn-info">
          <MdOutlineRateReview /> Write a review
        </button>
        <hr />
      </div>
      
      {businessReviews.map((review, index)=>{
        return <h4>{review.comment}</h4>
      })}
      
    </div>
  );
};

export default BusinessReviews;

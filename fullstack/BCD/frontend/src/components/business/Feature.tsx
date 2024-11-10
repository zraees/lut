import { useEffect, useState } from "react";
import { IBusiness } from "../../types/types";
import BusinessCard from "./BusinessCard";
import { useNavigate } from "react-router-dom";
import BusinessService from "../../services/business-service";

const Feature = () => {

  const INITIAL: IBusiness[] = [];
  const [businessData, setBusinessData] = useState(INITIAL);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const res: IBusiness[] = await BusinessService.getFeatureBusinesses();
        setBusinessData(res);
        //console.log('data',res);
      } catch (err) {
        console.log("err", err);
      } finally {
      }
    };

    fetchData();
  }, []);

  const redirectToDetail = (business: IBusiness) => {
    //console.log('businessId', business.businessId);
    navigate(`/business-detail/${business.businessId}`, { state: business});
  }

    return <>
    {businessData.length>0 && <div className="album py-5 bg-body-tertiary">
        <div className="container">
          <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
            {businessData.map((business: IBusiness) => (
              <div key={business.businessId} className="col">
                <BusinessCard business={business} redirectToDetail={redirectToDetail}></BusinessCard>
              </div>
            ))}
          </div>
        </div>
      </div>}</>
  //   <div className="container px-4 py-5" id="custom-cards">
  //   <h2 className="pb-2 border-bottom">Popular Local Businesses</h2>

  //   <div className="row row-cols-1 row-cols-lg-3 align-items-stretch g-4 py-5">
  //     <div className="col">
  //       <div className="card card-cover h-100 overflow-hidden text-bg-dark rounded-4 shadow-lg" style={{backgroundImage:"url('/images/business-1.png')"}}>
  //         <div className="d-flex flex-column h-100 p-5 pb-3 text-white text-shadow-1">
  //           <h3 className="pt-5 mt-5 mb-4 display-6 lh-1 fw-bold">Short title, long jacket</h3>
  //           <ul className="d-flex list-unstyled mt-auto">
  //             <li className="me-auto">
  //               <img src="https://github.com/twbs.png" alt="Bootstrap" width="32" height="32" className="rounded-circle border border-white"/>
  //             </li>
  //             <li className="d-flex align-items-center me-3">
  //               <svg className="bi me-2" width="1em" height="1em"><use xlinkHref="#geo-fill"></use></svg>
  //               <small>Earth</small>
  //             </li>
  //             <li className="d-flex align-items-center">
  //               <svg className="bi me-2" width="1em" height="1em"><use xlinkHref="#calendar3"></use></svg>
  //               <small>3d</small>
  //             </li>
  //           </ul>
  //         </div>
  //       </div>
  //     </div>

  //     <div className="col">
  //       <div className="card card-cover h-100 overflow-hidden text-bg-dark rounded-4 shadow-lg" style={{backgroundImage: "url('images/business-2.png')"}}>
  //         <div className="d-flex flex-column h-100 p-5 pb-3 text-white text-shadow-1">
  //           <h3 className="pt-5 mt-5 mb-4 display-6 lh-1 fw-bold">Much longer title that wraps to multiple lines</h3>
  //           <ul className="d-flex list-unstyled mt-auto">
  //             <li className="me-auto">
  //               <img src="https://github.com/twbs.png" alt="Bootstrap" width="32" height="32" className="rounded-circle border border-white"/>
  //             </li>
  //             <li className="d-flex align-items-center me-3">
  //               <svg className="bi me-2" width="1em" height="1em"><use xlinkHref="#geo-fill"></use></svg>
  //               <small>Pakistan</small>
  //             </li>
  //             <li className="d-flex align-items-center">
  //               <svg className="bi me-2" width="1em" height="1em"><use xlinkHref="#calendar3"></use></svg>
  //               <small>4d</small>
  //             </li>
  //           </ul>
  //         </div>
  //       </div>
  //     </div>

  //     <div className="col">
  //       <div className="card card-cover h-100 overflow-hidden text-bg-dark rounded-4 shadow-lg" style={{backgroundImage: "url('images/business-3.png')"}}>
  //         <div className="d-flex flex-column h-100 p-5 pb-3 text-shadow-1">
  //           <h3 className="pt-5 mt-5 mb-4 display-6 lh-1 fw-bold">Another longer title belongs here</h3>
  //           <ul className="d-flex list-unstyled mt-auto">
  //             <li className="me-auto">
  //               <img src="https://github.com/twbs.png" alt="Bootstrap" width="32" height="32" className="rounded-circle border border-white"/>
  //             </li>
  //             <li className="d-flex align-items-center me-3">
  //               <svg className="bi me-2" width="1em" height="1em"><use xlinkHref="#geo-fill"></use></svg>
  //               <small>California</small>
  //             </li>
  //             <li className="d-flex align-items-center">
  //               <svg className="bi me-2" width="1em" height="1em"><use xlinkHref="#calendar3"></use></svg>
  //               <small>5d</small>
  //             </li>
  //           </ul>
  //         </div>
  //       </div>
  //     </div>
  //   </div>
  // </div>
}

export default Feature;
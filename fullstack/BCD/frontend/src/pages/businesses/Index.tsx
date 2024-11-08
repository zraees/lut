import { useEffect, useState } from "react";
import SearchCriteria from "../../components/business/SearchCriteria";
import BusinessService from "../../services/business-service";
import BusinessCard from "../../components/business/BusinessCard";
import { IBusiness } from "../../types";

export const Index = () => {

  const INITIAL: IBusiness[] = []; 
  const [businessData, setBusinessData] = useState(INITIAL);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const res: IBusiness[] = await BusinessService.getBusinesses();
        setBusinessData(res);
        //console.log('data',res);
      } catch (err) {
        console.log("err", err);
      } finally {
      }
    };

    fetchData();
  }, []);
  return (
    <main className="business-bg">
      <SearchCriteria />

      <div className="album py-5 bg-body-tertiary">
        <div className="container">
          <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
            {businessData.map((business: IBusiness) => (
              <div key={business.businessId} className="col"><BusinessCard business={business}></BusinessCard></div>
            ))}
            
          </div>
        </div>
      </div>
    </main>
  );
};

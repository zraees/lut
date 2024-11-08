import axios from "axios";
import { IBusiness } from "../types";

const BusinessService = {
    getBusinesses : async () : Promise<IBusiness[]> => {
        const resp = await axios.get<IBusiness[]>("https://localhost:44323/api/Businesses/GetAllBusinesses");
        return resp.data;
    }      
}

export default BusinessService;
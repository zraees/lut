export interface IBusiness {
  businessId: number;
  name: string;
  description: string;
  location: string;
  address: string;
  phoneNumber: string;
  email: string;
  website: string;
  hoursOfOperation: string;
  category: ICategory;
  ownerId: number;
  businessPhotos: IBusinessPhoto[];
}

export interface ICategory {
  categoryId: number;
  name: string
  description: string;
}

export interface IBusinessPhoto {
  businessPhotoId: number;
  businessId: number
  url: string
  description: string;
}

export interface IBusinessCardProps {
  business: IBusiness;
}
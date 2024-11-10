export interface IBusiness {
  businessId: number;
  name: string;
  description: string;
  address: string;
  phoneNumber: string;
  email: string;
  website: string;
  hoursOfOperation: string;
  isFeatured: boolean,
  latitude: number,
  longitude: number,
  postalCode: number,
  city: ICity,
  category: ICategory;
  ownerId: number;
  businessPhotos: IBusinessPhoto[];
  businessReviews: IBusinessReview[];
}

export interface ICity {
  cityId: number;
  cityName: string
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

export interface IBusinessReview {
  businessReviewId: number;
  businessId: number;
  rating: number;
  comment: string;
  createdAt: Date;
  user: IUser;
}

export interface IUser {
  userId: number;
}

export interface IBusinessCardMapProps {
  latitude: number
  longitude: number
}

export interface IBusinessCardProps {
  business: IBusiness;
  redirectToDetail: any;
}

export interface IBusinessPhotoProp {
  businessPhotos: IBusinessPhoto[];
}


export interface IBusinessOverviewProp {
  business: IBusiness;
}

export interface IBusinessReviewsProp {
  businessReviews: IBusinessReview[];
}
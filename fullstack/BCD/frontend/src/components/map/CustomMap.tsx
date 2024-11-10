import { AdvancedMarker, APIProvider, Map, Pin } from "@vis.gl/react-google-maps"; 

import { IBusinessCardMapProps } from "../../types/types"; 

const CustomMap : React.FC<IBusinessCardMapProps> =({latitude, longitude})  => {
 
    type Poi ={ key: string, location: google.maps.LatLngLiteral }

    const locations: Poi[] = [
        //{key: 'operaHouse', location: { lat: 61.016323, lng: 25.660459 }},
        {key: 'operaHouse', location: { lat: latitude, lng: longitude }}, 
      ];

      console.log('latitude, longitude',latitude, longitude);

    const PoiMarkers = (props: {pois: Poi[]}) => {
        return (
          <>
            {props.pois.map( (poi: Poi) => (
              <AdvancedMarker
                key={poi.key}
                position={poi.location}>
              <Pin background={'#FBBC04'} glyphColor={'#000'} borderColor={'#000'} />
              </AdvancedMarker>
            ))}
          </>
        );
      };
      
  return (    
    <>
      <APIProvider
        apiKey={"AIzaSyBQ5jaaO7n8URV6zGPzMWK8WVhy9cFqpIU"}
        onLoad={() => console.log("Maps API has loaded.")}
      >
        <Map
          defaultZoom={15}
          mapId={"c4aa099f9112984d"}
          defaultCenter={{ lat: latitude, lng: longitude }}
          //defaultCenter={{ lat: 61.016323, lng: 25.660459 }}
        //   onCameraChanged={(ev: MapCameraChangedEvent) =>
        //     console.log(
        //       "camera changed:",
        //       ev.detail.center,
        //       "zoom:",
        //       ev.detail.zoom
        //     )
        //   }
        >
            <PoiMarkers pois={locations} />
        </Map>
      </APIProvider>
    </>
  );
};

export default CustomMap;

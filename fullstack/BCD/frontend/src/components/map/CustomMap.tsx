import {APIProvider, Map, MapCameraChangedEvent} from '@vis.gl/react-google-maps';

const CustomMap = () => {
  return (
    <>
      <APIProvider
        apiKey={"AIzaSyBQ5jaaO7n8URV6zGPzMWK8WVhy9cFqpIU"}
        onLoad={() => console.log("Maps API has loaded.")}
      >
        <Map
          defaultZoom={13}
          defaultCenter={{ lat: -33.860664, lng: 151.208138 }}
          onCameraChanged={(ev: MapCameraChangedEvent) =>
            console.log(
              "camera changed:",
              ev.detail.center,
              "zoom:",
              ev.detail.zoom
            )
          }
        ></Map>
      </APIProvider>
    </>
  );
};

export default CustomMap;

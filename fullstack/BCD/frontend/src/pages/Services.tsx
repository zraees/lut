const Services = () => {
    return (<div className="container ">
    
        <div className="p-5 mb-4 bg-body-tertiary rounded-3">
          <div className="container-fluid py-5">
            <h1 className="display-5 fw-bold">Our Services</h1>
            <p className="col-md-8 fs-4">At Business Community Directory (BCD), we connect you with local businesses. Explore comprehensive listings, read genuine reviews, and find top-rated services in your area. Whether you’re seeking dining, shopping, or entertainment, BCD is your go-to platform for discovering the best local experiences.</p>
            <button className="btn btn-primary btn-lg" type="button">Example button</button>
          </div>
        </div>
    
        <div className="row align-items-md-stretch">
          <div className="col-md-6">
            <div className="h-100 p-5 text-bg-dark rounded-3">
              <h2>Change the background</h2>
              <p>Swap the background-color utility and add a `.text-*` color utility to mix up the jumbotron look. Then, mix and match with additional component themes and more.</p>
              <button className="btn btn-outline-light" type="button">Example button</button>
            </div>
          </div>
          <div className="col-md-6">
            <div className="h-100 p-5 bg-body-tertiary border rounded-3">
              <h2>Add borders</h2>
              <p>Or, keep it light and add a border for some added definition to the boundaries of your content. Be sure to look under the hood at the source HTML here as we've adjusted the alignment and sizing of both column's content for equal-height.</p>
              <button className="btn btn-outline-secondary" type="button">Example button</button>
            </div>
          </div>
        </div>
      </div>);
}

export default Services;
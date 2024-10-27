const Hero = () => {
    return <div className="container col-xxl-8">  
    <div className="row flex-lg-row-reverse align-items-center">
      <div className="col-10 col-sm-8 col-lg-6">
        <img src="/images/business-2.png" className="d-block mx-lg-auto img-fluid" alt="Bootstrap Themes" width="700" height="500" loading="lazy"/>
      </div>
      <div className="col-lg-6">
        <h1 className="display-5 fw-bold text-body-emphasis lh-1 mb-3">Discover Local, Support Local</h1>
        <p className="lead">BCD is your go-to guide for finding trusted local businesses. From restaurants to services, explore community-driven reviews, ratings, and personalized recommendations that help you make the best choices—while supporting businesses that make your area unique.</p>
        <div className="d-grid gap-2 d-md-flex justify-content-md-start">
          <button type="button" className="btn btn-primary btn-lg px-4 me-md-2">Explore Your Community</button> 
        </div>
      </div>
    </div>
  </div>
}

export default Hero;
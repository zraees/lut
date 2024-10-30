import { Form } from "react-router-dom";
import { FaSearchLocation } from "react-icons/fa";

const BusinessSearchCriteria = () => {
  return (
    <section className="py-5 text-center container">
      <div className="row py-lg-1">
        <div className="col-lg-6 col-md-8 mx-auto">
          <h1 className="fw-light">Find a Business</h1>

          <div className="py-lg-2 mb-3">
            Explore top restaurants, bars, shops, and attractions in cities
            worldwide. Uncover local favorites and must-visit spots for your
            next adventure!
          </div>

          <Form className="needs-validation">
            <div className="row g-3">
              <div className="col-md-auto">
                <input
                  type="text"
                  className="form-control"
                  id="business"
                  placeholder="I'm looking for ..."
                  value=""
                />
              </div>

              <div className="col-md-auto">
                <input
                  type="text"
                  className="form-control"
                  id="zipCode"
                  placeholder="Zip code or City"
                  value=""
                />
              </div>

              <div className="col-md-auto">
                <button className="btn btn-success" type="submit">
                  <FaSearchLocation /> Search
                </button>
              </div>

              {/* <div className="col-md-5">
                <label htmlFor="country" className="form-label">
                  Country
                </label>
                <select className="form-select" id="country">
                  <option value="">Choose...</option>
                  <option>United States</option>
                </select>
                <div className="invalid-feedback">
                  Please select a valid country.
                </div>
              </div> */}
            </div>
            <div className="row g-3">
              <div className="col-auto-">
                categories
                <ul className="categories">
                  <li className="categories">
                    <a
                      className="categoryLink"
                      href="/explore?near=Pakistan&amp;cat=food"
                    >
                      <span className="categoryText">Food</span>
                    </a>
                  </li>
                  <li className="categories">two</li>
                  <li className="categories">three</li>
                  <li className="categories">four</li>
                  <li className="categories">five</li>
                </ul>
              </div>
            </div>
            {/* <hr className="my-4" /> */}
          </Form>
        </div>
      </div>
    </section>
  );
};

export default BusinessSearchCriteria;

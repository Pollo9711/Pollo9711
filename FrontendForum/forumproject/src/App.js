import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Route} from "react-router-dom";
import {Routes} from "react-router-dom";
import Header from "./components/layout/Header/Header";
import Footer from "./components/layout/Footer/Footer";

function App() {
  return (
      <>
          <Header/>

            <div className="App">

              <Routes>
                <Route path={'/'} element={<Home/>} />
                <Route path={'/post'} element={<Post/>} />
                <Route path={'/profile'} element={<Profile/>} />
                <Route path={'/registrati'} element={<Registrati/>} />
              </Routes>

            </div>

          <Footer/>

      </>
  );
}

export default App;
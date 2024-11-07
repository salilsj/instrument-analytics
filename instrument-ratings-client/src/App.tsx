import './App.css';
import { AppRoutes } from './appRoutes';

function App() {
  return (
    <div className="app">
      <header className="text-lg app-header">
        <p>
          Instrument Analytics App
        </p>

      </header>
      <main >
        <div className='mb-20 '>
          {/* Implement routing in a separate file/ component  */}
          <AppRoutes /> 
        </div>
      </main>
      <footer className='app-footer'>
        <p className='text-xs'>
          Developed by Salil Joshi
        </p>
      </footer>
    </div>
  );
}

export default App;

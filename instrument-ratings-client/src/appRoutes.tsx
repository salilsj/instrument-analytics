
import { appAccess, useAuthState } from './authProvider';
import InstrumentRatings from './components/instrument-ratings-component';

export const AppRoutes: React.FC = () => {
    const { hasPermission } = useAuthState();

    return (
        <>
            <div>
                {
                    hasPermission(appAccess.instrumentRatings) &&
                    (
                        <InstrumentRatings />
                    )
                }
            </div>
            {
            /* 
            
            // Implement routing here
            <Routes>
                {
                    hasPermission(appAccess.instrumentRatings) &&
                    (
                        <Route path="ratings" element={<InstrumentRatings />} />
                    )
                }
            </Routes> */}
        </>

    )
}
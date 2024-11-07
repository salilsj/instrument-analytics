export enum appAccess  {
    instrumentRatings,
    admin,    
};

export const useAuthState = () => {
    return {
        hasPermission : (access: appAccess) => access === appAccess.instrumentRatings, // real implementation here to control access on UI side. 
        hasLoggedIn : () => true // real implementation here to implement user auth checks. 
    }
};



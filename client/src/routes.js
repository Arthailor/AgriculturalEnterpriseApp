import MainMenu from "./pages/MainMenu"
import AnimalsMenu from "./pages/AnimalsMenu"
import { ANIMALS_ROUTE, MAIN_ROUTE} from "./utils/consts"

export const routes = [
    {
        path: MAIN_ROUTE,
        Component: MainMenu
    },
    {
        path: ANIMALS_ROUTE,
        Component: AnimalsMenu
    }
]
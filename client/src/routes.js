import MainMenu from "./pages/MainMenu"
import AnimalsAndPasturesMenu from "./pages/AnimalsAndPasturesMenu"
import CropsAndFieldsListMenu from "./pages/CropsAndFieldsMenu"
import { MAIN_ROUTE, ANIMALS_AND_PASTURES_ROUTE, CROPS_AND_FIELDS_ROUTE} from "./utils/consts"

export const routes = [
    {
        path: MAIN_ROUTE,
        Component: MainMenu
    },
    {
        path: ANIMALS_AND_PASTURES_ROUTE,
        Component: AnimalsAndPasturesMenu
    },
    {
        path: CROPS_AND_FIELDS_ROUTE,
        Component: CropsAndFieldsListMenu
    }
]
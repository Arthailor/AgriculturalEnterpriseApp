import { useEffect, useState } from 'react'
import { Container, Row, Col, Button } from 'react-bootstrap'
import { useDispatch, useSelector } from 'react-redux'
import { setCrops, setTotalCount as setCropsTotalCount, setPage as setCropsPage} from '../store/cropsSlice';
import { setFields, setTotalCount as setFieldsTotalCount, setPage as setFieldsPage} from '../store/fieldsSlice';
import Pages from '../components/Pages'
import { setName } from '../store/pageSlice';
import FieldsList from '../components/Fields/FieldsList';
import { fetchCrops, fetchFields } from '../http/modelAPI';
import CreateFieldModal from '../components/Fields/CreateFieldModal';

export default function CropsAndFieldsListMenu() {

    const { crops, page: cropsPage, totalCount: cropsTotalCount, limit: cropsLimit} = useSelector((state) => {
        return state.crops;
    });

    const { fields, page: fieldsPage, totalCount: fieldsTotalCount, limit: fieldsLimit} = useSelector((state) => {
        return state.fields;
    });

    const dispatch = useDispatch();

    dispatch(setName('Crops and fields'))

    const handleCrops = (c) => {
        dispatch(setCrops(c))
    }
    const handleCropsTotalCount = (c) => {
        dispatch(setCropsTotalCount(c))
    }

    const handleFields = (f) => {
        dispatch(setFields(f))
    }
    const handleFieldsTotalCount = (c) => {
        dispatch(setFieldsTotalCount(c))
    }
    const handleFieldsPage = (p) => {
        dispatch(setFieldsPage(p))
    }

    const loadCrops = () => {
        fetchCrops(1, 9999).then(data => {
            handleCrops(data.rows)
            handleCropsTotalCount(data.count)
        })
    }

    useEffect(() => {
        loadCrops()
    }, [cropsTotalCount])

    const loadFields = () => {
        fetchFields(fieldsPage, fieldsLimit).then(data => {
            handleFields(data.rows)
            handleFieldsTotalCount(data.count)
        })
    }

    useEffect(() => {
        loadFields()
    }, [fieldsPage, fieldsTotalCount])

    const [createFieldVisible, setCreateFieldVisible] = useState(false)

    return (
        <Container>
            <Row className="mt-2">
                <Col md={2}>
                    <Button variant={"outline-success"} style={{ width: "100%" }} className="mt-4 p-2" onClick={() => setCreateFieldVisible(true)}>Add field</Button>
                    <Pages totalCount={fieldsTotalCount} limit={fieldsLimit} page={fieldsPage} handlePage={(p) => handleFieldsPage(p)} />
                </Col>
                <Col md={10} className="mt-2">
                    <FieldsList fields = {fields} crops = {crops} reload = {a=> {loadFields(); loadCrops()}}/>
                </Col>
            </Row>
            <CreateFieldModal show={createFieldVisible} onHide={() => setCreateFieldVisible(false)}/>
        </Container>
    )
}
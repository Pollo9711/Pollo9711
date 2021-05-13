import {IconButton} from "@material-ui/core";
import AddIcon from "@material-ui/icons/Add";
import Accordion from "@material-ui/core/Accordion";
import AccordionSummary from "@material-ui/core/AccordionSummary";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import Typography from "@material-ui/core/Typography";
import AccordionDetails from "@material-ui/core/AccordionDetails";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import React from "react";
import {useStyles} from "../../../utils/CssClasses";


const CustomAccordion = () => {


    const classes = useStyles();


    return (
        <>
                <Accordion>
                    <AccordionSummary
                        expandIcon={<ExpandMoreIcon />}
                        aria-controls="panel1a-content"
                        id="panel"
                    >
                        <Typography className={classes.heading}>Post 1</Typography>
                    </AccordionSummary>
                    <AccordionDetails>
                        <Typography>
                            Descrizione post
                        </Typography>
                        <IconButton  id={"delete"} aria-label="delete">
                            <DeleteIcon />
                        </IconButton>
                        <IconButton  id={"edit"} aria-label="EditIcon">
                            <EditIcon />
                        </IconButton>
                    </AccordionDetails>
                </Accordion>
        </>
    );
}
export default CustomAccordion;
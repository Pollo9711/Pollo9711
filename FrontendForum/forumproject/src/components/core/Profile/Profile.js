import "./Profile.css"
import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Accordion from '@material-ui/core/Accordion';
import AccordionSummary from '@material-ui/core/AccordionSummary';
import AccordionDetails from '@material-ui/core/AccordionDetails';
import Typography from '@material-ui/core/Typography';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import DeleteIcon from '@material-ui/icons/Delete';
import {IconButton} from "@material-ui/core";
import EditIcon from '@material-ui/icons/Edit';
import AddIcon from '@material-ui/icons/Add';

const Profile = () => {


    const useStyles = makeStyles((theme) => ({
        root: {
            width: '100%',
            '& > *': {
                margin: theme.spacing(1),
            },
        },
        heading: {
            fontSize: theme.typography.pxToRem(15),
            fontWeight: theme.typography.fontWeightRegular,
        },
    }));

          const classes = useStyles();


        return (
        <>
            <div className={"profile"}>
                <div className={"image"}  >

                </div>
                <h6>#ID:</h6>
                <h3>Username:</h3>
                <h5>Email:</h5>

                <div>
                    <IconButton  id={"add"} aria-label="Add">
                        <AddIcon />
                    </IconButton>
                    Add a post
                </div>
                

                <div id={"totalPanel"} className={classes.root}>
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
                    <Accordion>
                        <AccordionSummary
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel2a-content"
                            id="panel"
                        >
                            <Typography className={classes.heading}>Post 2</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Typography>
                                Descrizione post.
                            </Typography>
                            <IconButton  id={"delete"} aria-label="delete">
                                <DeleteIcon />
                            </IconButton>
                            <IconButton  id={"edit"} aria-label="EditIcon">
                                <EditIcon />
                            </IconButton>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion>
                        <AccordionSummary
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel3a-content"
                            id="panel"
                        >
                            <Typography className={classes.heading}>Post 3</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Typography>
                                Descrizione post.
                            </Typography>
                            <IconButton  id={"delete"} aria-label="delete">
                                <DeleteIcon />
                            </IconButton>
                            <IconButton  id={"edit"} aria-label="EditIcon">
                                <EditIcon />
                            </IconButton>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion>
                        <AccordionSummary
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel4a-content"
                            id="panel"
                        >
                            <Typography className={classes.heading}>Post 4</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Typography>
                                Descrizione post.
                            </Typography>
                            <IconButton  id={"delete"} aria-label="delete">
                                <DeleteIcon />
                            </IconButton>
                            <IconButton  id={"edit"} aria-label="EditIcon">
                                <EditIcon />
                            </IconButton>
                        </AccordionDetails>
                    </Accordion>
                </div>







            </div>
        </>
    );
}

export default Profile;
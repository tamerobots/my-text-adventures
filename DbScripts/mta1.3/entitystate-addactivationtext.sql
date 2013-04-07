ALTER TABLE mta.entitystate
 CHANGE Description Description VARCHAR(10000),
 ADD ActivationText VARCHAR(10000) AFTER ActivationVerb;

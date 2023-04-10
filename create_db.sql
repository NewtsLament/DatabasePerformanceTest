CREATE TABLE songs (
	track_id CHAR(18) NOT NULL,
	time_stamp TIMESTAMP(6), 
	artist NVARCHAR(120) NOT NULL, 
	title NVARCHAR(120) NOT NULL,
	PRIMARY KEY(track_id)
);

CREATE TABLE similars (
	track_id CHAR(18) NOT NULL,
	similar_to_track_id CHAR(18) NOT NULL,
	similarity FLOAT NOT NULL,
	PRIMARY KEY(track_id,similar_to_track_id),
	CONSTRAINT fk_tracks_similars_1 FOREIGN KEY (track_id) REFERENCES songs (track_id),
	CONSTRAINT fk_tracks_similars_2 FOREIGN KEY (similar_to_track_id) REFERENCES songs (track_id)
);

CREATE TABLE tags (
	tag_id INT NOT NULL AUTO_INCREMENT,
	title NVARCHAR(120),
	PRIMARY KEY(tag_id)
);

CREATE TABLE songs_tags (
	track_id CHAR(18) NOT NULL,
	tag_id INT NOT NULL,
	weight TINYINT NOT NULL,
	PRIMARY KEY (track_id,tag_id),
	CONSTRAINT fk_songs_tags_songs_1 FOREIGN KEY (track_id) REFERENCES songs (track_id),
	CONSTRAINT fk_songs_tags_tags_1 FOREIGN KEY (tag_id) REFERENCES tags (tag_id)
);
package cr.ac.ucr.teleatlantico.domain;

import java.util.Date;

public class Comment {

	private int commentId;
	
	private String description;
	
	private String createBy;
	
	private Date createAt;
	
	private String modifyBy;
	
	private Date modifyAt;
	
	
	
	public Comment(int commentId, String description, String createBy, Date createAt, String modifyBy, Date modifyAt) {
		this.commentId = commentId;
		this.description = description;
		this.createBy = createBy;
		this.createAt = createAt;
		this.modifyBy = modifyBy;
		this.modifyAt = modifyAt;
	}
	
	public Comment() {
		this.commentId = 0;
		this.description = "";
		this.createBy = "";
		this.createAt = new Date();
		this.modifyBy = "";
		this.modifyAt = new Date();
	}

	public String getCreateBy() {
		return createBy;
	}

	public void setCreateBy(String createBy) {
		this.createBy = createBy;
	}

	public Date getCreateAt() {
		return createAt;
	}

	public void setCreateAt(Date createAt) {
		this.createAt = createAt;
	}

	public String getModifyBy() {
		return modifyBy;
	}

	public void setModifyBy(String modifyBy) {
		this.modifyBy = modifyBy;
	}

	public Date getModifyAt() {
		return modifyAt;
	}

	public void setModifyAt(Date modifyAt) {
		this.modifyAt = modifyAt;
	}
}

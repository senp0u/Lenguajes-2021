package cr.ac.ucr.teleatlantico.domain;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "Comment")
public class Comment {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "CommentId")
	private int commentId;
	
	@Column(name = "Description", nullable = false ,unique = false, length = 100)
	private String description;
	
	@Column(name = "CreateBy", nullable = false ,unique = false, length = 25)
	private String createBy;
	
	@Column(name = "CreateAt", nullable = false ,unique = false)
	private Date createAt;
	
	@Column(name = "ModifyBy", unique = false, length = 25)
	private String modifyBy;
	
	@Column(name = "ModifyAt", unique = false)
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

	public int getCommentId() {
		return commentId;
	}

	public void setCommentId(int commentId) {
		this.commentId = commentId;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
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

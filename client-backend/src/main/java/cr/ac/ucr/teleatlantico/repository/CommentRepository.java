package cr.ac.ucr.teleatlantico.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import cr.ac.ucr.teleatlantico.domain.Comment;



@Repository
public interface CommentRepository extends JpaRepository<Comment, Integer>{

}

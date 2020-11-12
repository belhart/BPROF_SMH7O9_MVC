/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package eredmeny;

/**
 *
 * @author Admin
 */
public class Eredmeny {
    private Integer predictedPosition;
    private Integer predictedPoint;

    public Eredmeny() {
    }

    public Eredmeny(Integer predictedPosition, Integer predictedPoint) {
        this.predictedPosition = predictedPosition;
        this.predictedPoint = predictedPoint;
    }

    public Integer getPredictedPosition() {
        return predictedPosition;
    }

    public Integer getPredictedPoint() {
        return predictedPoint;
    }

    public void setPredictedPosition(Integer predictedPosition) {
        this.predictedPosition = predictedPosition;
    }

    public void setPredictedPoint(Integer predictedPoint) {
        this.predictedPoint = predictedPoint;
    }
    
    
}
